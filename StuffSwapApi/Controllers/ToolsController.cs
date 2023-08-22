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
  public class ToolsController : ControllerBase
  {
    private readonly StuffSwapApiContext _db;

    // todo  add StuffSwapApiContext db, 
    public ToolsController(StuffSwapApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<Tool>>> Get()
    {
      return await _db.Tools.ToListAsync();
    }


  }
}