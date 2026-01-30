using Benistar.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Benistar.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BenefitsController : ControllerBase
{
    private readonly BenefitsDbContext _context;

    public BenefitsController(BenefitsDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Benefit>>> GetBenefits()
    {
        try
        {
            return await _context.Benefits.ToListAsync();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Benefit>> PostBenefit(Benefit benefit)
    {
        try
        {
            _context.Benefits.Add(benefit);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBenefits), new { id = benefit.BenefitId }, benefit);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBenefit(int id)
    {
        try
        {
            var benefit = await _context.Benefits.FindAsync(id);
            if (benefit == null)
                return NotFound();

            benefit.IsActive = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("{id}/undelete")]
    public async Task<IActionResult> UndeleteBenefit(int id)
    {
        try
        {
            var benefit = await _context.Benefits.FindAsync(id);
            if (benefit == null)
                return NotFound();

            benefit.IsActive = true;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
