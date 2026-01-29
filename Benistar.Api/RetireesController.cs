
using Benistar.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Benistar.Api;

[ApiController]
[Route("api/retirees")]
public class RetireesController : ControllerBase
{
    private readonly BenefitsDbContext _db;
    public RetireesController(BenefitsDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> Get() =>
        Ok(await _db.Retirees.ToListAsync());

    [HttpPost]
    public async Task<IActionResult> Create(Retiree retiree)
    {
        _db.Retirees.Add(retiree);
        await _db.SaveChangesAsync();
        return Ok(retiree);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var retiree = await _db.Retirees.FindAsync(id);
        
        if (retiree == null)
            return NotFound();
        
        retiree.IsActive = false;
        await _db.SaveChangesAsync();
        
        return NoContent();
    }

    [HttpPut("{id}/undelete")]
    public async Task<IActionResult> Undelete(int id)
    {
        var retiree = await _db.Retirees.FindAsync(id);
        
        if (retiree == null)
            return NotFound();
        
        retiree.IsActive = true;
        await _db.SaveChangesAsync();
        
        return NoContent();
    }
}
