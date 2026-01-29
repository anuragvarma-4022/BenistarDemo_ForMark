using Benistar.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Benistar.Api.Controllers;

[ApiController]
[Route("api")]
public class RetireeBenefitsController : ControllerBase
{
    private readonly BenefitsDbContext _context;

    public RetireeBenefitsController(BenefitsDbContext context) => _context = context;

    [HttpPost("retirees/{retireeId}/benefits/enroll")]
    public async Task<ActionResult<List<RetireeBenefit>>> EnrollInBenefits(
        int retireeId, 
        List<EnrollmentRequest> enrollments)
    {
        // Validate retiree exists
        var retiree = await _context.Retirees.FindAsync(retireeId);
        if (retiree == null)
            return NotFound($"Retiree with ID {retireeId} not found");

        // Validate dates
        foreach (var enrollment in enrollments)
        {
            if (enrollment.CoverageEndDate.HasValue && 
                enrollment.CoverageEndDate.Value <= enrollment.CoverageStartDate)
            {
                return BadRequest("Coverage end date must be after start date");
            }
        }

        // Get existing enrollments to check for duplicates
        var benefitIds = enrollments.Select(e => e.BenefitId).ToList();
        var existingEnrollments = await _context.RetireeBenefits
            .Where(rb => rb.RetireeId == retireeId && 
                         benefitIds.Contains(rb.BenefitId) && 
                         rb.IsActive)
            .Select(rb => rb.BenefitId)
            .ToListAsync();

        if (existingEnrollments.Any())
        {
            return BadRequest($"Retiree is already enrolled in benefit(s): {string.Join(", ", existingEnrollments)}");
        }

        // Validate all benefits exist
        var benefits = await _context.Benefits
            .Where(b => benefitIds.Contains(b.BenefitId))
            .ToListAsync();

        if (benefits.Count != benefitIds.Count)
        {
            return BadRequest("One or more benefit IDs are invalid");
        }

        // Create enrollments
        var newEnrollments = new List<RetireeBenefit>();
        foreach (var enrollment in enrollments)
        {
            var retireeBenefit = new RetireeBenefit
            {
                RetireeId = retireeId,
                BenefitId = enrollment.BenefitId,
                CoverageStartDate = enrollment.CoverageStartDate,
                CoverageEndDate = enrollment.CoverageEndDate,
                IsActive = true,
                EnrolledAt = DateTime.UtcNow
            };
            _context.RetireeBenefits.Add(retireeBenefit);
            newEnrollments.Add(retireeBenefit);
        }

        await _context.SaveChangesAsync();

        // Return simple response without navigation properties to avoid circular reference
        var enrollmentIds = newEnrollments.Select(e => e.RetireeBenefitId).ToList();
        
        return CreatedAtAction(nameof(GetRetireeEnrollments), new { retireeId }, new { 
            Message = $"Successfully enrolled in {enrollmentIds.Count} benefit(s)", 
            EnrollmentIds = enrollmentIds 
        });
    }

    [HttpGet("retirees/{retireeId}/benefits")]
    public async Task<ActionResult<List<RetireeBenefit>>> GetRetireeEnrollments(int retireeId)
    {
        var retiree = await _context.Retirees.FindAsync(retireeId);
        if (retiree == null)
            return NotFound($"Retiree with ID {retireeId} not found");

        var enrollments = await _context.RetireeBenefits
            .Include(rb => rb.Benefit)
            .Where(rb => rb.RetireeId == retireeId && rb.IsActive)
            .ToListAsync();

        return Ok(enrollments);
    }

    [HttpDelete("retireebenefits/{id}")]
    public async Task<IActionResult> DeleteEnrollment(int id)
    {
        var enrollment = await _context.RetireeBenefits.FindAsync(id);
        if (enrollment == null)
            return NotFound();

        // Hard delete
        _context.RetireeBenefits.Remove(enrollment);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
