
using Benistar.Shared;
using Microsoft.EntityFrameworkCore;

namespace Benistar.Api;

public class BenefitsDbContext : DbContext
{
    public BenefitsDbContext(DbContextOptions<BenefitsDbContext> options) : base(options) {}

    public DbSet<Retiree> Retirees => Set<Retiree>();
    public DbSet<Benefit> Benefits => Set<Benefit>();
    public DbSet<RetireeBenefit> RetireeBenefits => Set<RetireeBenefit>();

    /* protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure decimal precision for MonthlyPremium
        modelBuilder.Entity<Benefit>()
            .Property(b => b.MonthlyPremium)
            .HasPrecision(18, 2);

        // Seed Benefits
        modelBuilder.Entity<Benefit>().HasData(
            new Benefit
            {
                BenefitId = 1,
                BenefitName = "Medicare Supplement Plan F",
                BenefitType = "Medical",
                ProviderName = "Blue Cross Blue Shield",
                MonthlyPremium = 185.50m,
                IsActive = true
            },
            new Benefit
            {
                BenefitId = 2,
                BenefitName = "Medicare Advantage HMO",
                BenefitType = "Medical",
                ProviderName = "UnitedHealthcare",
                MonthlyPremium = 0.00m,
                IsActive = true
            },
            new Benefit
            {
                BenefitId = 3,
                BenefitName = "Dental PPO",
                BenefitType = "Dental",
                ProviderName = "Delta Dental",
                MonthlyPremium = 45.00m,
                IsActive = true
            },
            new Benefit
            {
                BenefitId = 4,
                BenefitName = "Vision Plan",
                BenefitType = "Vision",
                ProviderName = "VSP",
                MonthlyPremium = 18.75m,
                IsActive = true
            },
            new Benefit
            {
                BenefitId = 5,
                BenefitName = "Prescription Drug Plan",
                BenefitType = "Pharmacy",
                ProviderName = "CVS Caremark",
                MonthlyPremium = 32.50m,
                IsActive = true
            }
        );

        // Seed Retirees
        modelBuilder.Entity<Retiree>().HasData(
            new Retiree
            {
                RetireeId = 1,
                FirstName = "Anurag",
                LastName = "Varma",
                DateOfBirth = new DateTime(1955, 3, 15),
                Email = "anurag.varma@benistar.com",
                IsActive = true,
                CreatedAt = new DateTime(2024, 1, 10)
            },
            new Retiree
            {
                RetireeId = 2,
                FirstName = "Mark",
                LastName = "Johnson",
                DateOfBirth = new DateTime(1958, 7, 22),
                Email = "mark.johnson@benistar.com",
                IsActive = true,
                CreatedAt = new DateTime(2024, 2, 15)
            },
            new Retiree
            {
                RetireeId = 3,
                FirstName = "Robert",
                LastName = "Williams",
                DateOfBirth = new DateTime(1953, 11, 8),
                Email = "robert.williams@benistar.com",
                IsActive = true,
                CreatedAt = new DateTime(2024, 3, 20)
            },
            new Retiree
            {
                RetireeId = 4,
                FirstName = "Patricia",
                LastName = "Brown",
                DateOfBirth = new DateTime(1960, 5, 30),
                Email = "patricia.brown@benistar.com",
                IsActive = true,
                CreatedAt = new DateTime(2024, 4, 5)
            }
        );

        // Seed RetireeBenefits
        modelBuilder.Entity<RetireeBenefit>().HasData(
            new RetireeBenefit
            {
                RetireeBenefitId = 1,
                RetireeId = 1,
                BenefitId = 1,
                CoverageStartDate = new DateTime(2024, 1, 1),
                IsActive = true,
                EnrolledAt = new DateTime(2024, 1, 10)
            },
            new RetireeBenefit
            {
                RetireeBenefitId = 2,
                RetireeId = 1,
                BenefitId = 3,
                CoverageStartDate = new DateTime(2024, 1, 1),
                IsActive = true,
                EnrolledAt = new DateTime(2024, 1, 10)
            },
            new RetireeBenefit
            {
                RetireeBenefitId = 3,
                RetireeId = 2,
                BenefitId = 2,
                CoverageStartDate = new DateTime(2024, 2, 1),
                IsActive = true,
                EnrolledAt = new DateTime(2024, 2, 15)
            },
            new RetireeBenefit
            {
                RetireeBenefitId = 4,
                RetireeId = 2,
                BenefitId = 4,
                CoverageStartDate = new DateTime(2024, 2, 1),
                IsActive = true,
                EnrolledAt = new DateTime(2024, 2, 15)
            },
            new RetireeBenefit
            {
                RetireeBenefitId = 5,
                RetireeId = 3,
                BenefitId = 1,
                CoverageStartDate = new DateTime(2024, 3, 1),
                IsActive = true,
                EnrolledAt = new DateTime(2024, 3, 20)
            },
            new RetireeBenefit
            {
                RetireeBenefitId = 6,
                RetireeId = 3,
                BenefitId = 5,
                CoverageStartDate = new DateTime(2024, 3, 1),
                IsActive = true,
                EnrolledAt = new DateTime(2024, 3, 20)
            },
            new RetireeBenefit
            {
                RetireeBenefitId = 7,
                RetireeId = 4,
                BenefitId = 2,
                CoverageStartDate = new DateTime(2024, 4, 1),
                IsActive = true,
                EnrolledAt = new DateTime(2024, 4, 5)
            }
        );
    } */
}
