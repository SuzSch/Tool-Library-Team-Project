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

    [HttpGet("{id}")]
    public async Task<ActionResult<Tool>> GetTool(int id)
    {
      Tool tool = await _db.Tools.FindAsync(id);
      if (tool == null)
      {
        return NotFound();
      }
      return tool;
    }

    [HttpPost]
    public async Task<ActionResult> Post(Tool tool)
    {
      await _db.Tools.AddAsync(tool);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetTool), new { id = tool.ToolId }, tool);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Tool>> Put(int id, Tool tool)
    {
      if (id != tool.ToolId)
      {
        return BadRequest();
      }
      // the async part is not the update but the save
      _db.Tools.Update(tool);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ToolExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      //204 code in empty object shows success
      return NoContent();
    }

    private bool ToolExists(int id)
    {
      return _db.Tools.Any(e => e.ToolId == id);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Tool>> DeleteTool(int id)
    {
      Tool deleteTool = await _db.Tools.FindAsync(id);
      if (deleteTool == null)
      {
        return NotFound();
      }
      _db.Tools.Remove(deleteTool);
      await _db.SaveChangesAsync();
      return NoContent();
    }


  }
}