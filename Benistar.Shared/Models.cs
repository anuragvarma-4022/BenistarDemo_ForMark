
namespace Benistar.Shared;

public class Retiree
{
    public int RetireeId { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public DateTime DateOfBirth { get; set; }
    public string? Email { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<RetireeBenefit> RetireeBenefits { get; set; } = new List<RetireeBenefit>();
}

public class Benefit
{
    public int BenefitId { get; set; }
    public string BenefitName { get; set; } = "";
    public string BenefitType { get; set; } = "";
    public string? ProviderName { get; set; }
    public decimal MonthlyPremium { get; set; }
    public bool IsActive { get; set; }
}

public class RetireeBenefit
{
    public int RetireeBenefitId { get; set; }
    public int RetireeId { get; set; }
    public int BenefitId { get; set; }
    public DateTime CoverageStartDate { get; set; }
    public DateTime? CoverageEndDate { get; set; }
    public bool IsActive { get; set; }
    public DateTime EnrolledAt { get; set; }
    public Retiree? Retiree { get; set; }
    public Benefit? Benefit { get; set; }
}
