using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.EntityFrameworkCore;
using StuffSwapApi.Models;

namespace StuffSwapApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly StuffSwapApiContext _db;
        IConfiguration configuration;

        // todo  add StuffSwapApiContext db, 
        public AppUsersController(StuffSwapApiContext db, IConfiguration configuration)
        {
            _db = db;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> Post(AppUser appUser)
        {
            await _db.AppUsers.AddAsync(appUser);
            await _db.SaveChangesAsync();
            return NoContent();
        }


        [HttpPost("/GetToken")]
        public IActionResult GetToken(AppUser user)
        {
            IActionResult response = Unauthorized();

            if (user != null)
            {
#nullable enable
            AppUser? appUserExists = _db.AppUsers.FirstOrDefault(entry => entry.UserName == user.UserName && entry.UserPassword == user.UserPassword);
#nullable disable
                if (appUserExists != null)
                // if (user.UserName.Equals("sampleUser@gmail.com") && user.UserPassword.Equals("samplePass"))
                {
                    var issuer = configuration["Jwt:Issuer"];
                    var audience = configuration["Jwt:Audience"];
                    var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
                    var signingCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature
                    );

                    var subject = new ClaimsIdentity(new[]
                    {
                        //user Id claim: needs to find out what AppUserId is with a query of the database somewhere above this branching logic
                        // new Claim("AppUserId", user.AppUserId.ToString()),
                        new Claim("AppUserId", appUserExists.AppUserId.ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                    }
                    );

                    var expires = DateTime.UtcNow.AddMinutes(60);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = subject,
                        Expires = expires,
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = signingCredentials
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);

                    return Ok(jwtToken);
                }
            }

            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetAppUser(int id)
        {
        AppUser appUser= await _db.AppUsers.FindAsync(id);
        if (appUser == null)
        {
            return NotFound();
        }
        return appUser;
        }


    }
}