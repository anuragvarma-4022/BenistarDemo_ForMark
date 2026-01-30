using Benistar.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Benistar.Api.Controllers;

[ApiController]
[Route("api/retirees")]
public class RetireesController : ControllerBase
{
    private readonly BenefitsDbContext _db;
    public RetireesController(BenefitsDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await _db.Retirees.ToListAsync());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(Retiree retiree)
    {
        try
        {
            _db.Retirees.Add(retiree);
            await _db.SaveChangesAsync();
            return Ok(retiree);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var retiree = await _db.Retirees.FindAsync(id);
            
            if (retiree == null)
                return NotFound();
            
            retiree.IsActive = false;
            await _db.SaveChangesAsync();
            
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id}/undelete")]
    public async Task<IActionResult> Undelete(int id)
    {
        try
        {
            var retiree = await _db.Retirees.FindAsync(id);
            
            if (retiree == null)
                return NotFound();
            
            retiree.IsActive = true;
            await _db.SaveChangesAsync();
            
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
