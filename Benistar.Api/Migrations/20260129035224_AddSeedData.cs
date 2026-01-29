using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Benistar.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Benefits",
                columns: new[] { "BenefitId", "BenefitName", "BenefitType", "IsActive", "MonthlyPremium", "ProviderName" },
                values: new object[,]
                {
                    { 1, "Medicare Supplement Plan F", "Medical", true, 185.50m, "Blue Cross Blue Shield" },
                    { 2, "Medicare Advantage HMO", "Medical", true, 0.00m, "UnitedHealthcare" },
                    { 3, "Dental PPO", "Dental", true, 45.00m, "Delta Dental" },
                    { 4, "Vision Plan", "Vision", true, 18.75m, "VSP" },
                    { 5, "Prescription Drug Plan", "Pharmacy", true, 32.50m, "CVS Caremark" }
                });

            migrationBuilder.InsertData(
                table: "Retirees",
                columns: new[] { "RetireeId", "CreatedAt", "DateOfBirth", "Email", "FirstName", "IsActive", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1955, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.smith@email.com", "John", true, "Smith" },
                    { 2, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1958, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "mary.johnson@email.com", "Mary", true, "Johnson" },
                    { 3, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1953, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "robert.williams@email.com", "Robert", true, "Williams" },
                    { 4, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1960, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "patricia.brown@email.com", "Patricia", true, "Brown" }
                });

            migrationBuilder.InsertData(
                table: "RetireeBenefits",
                columns: new[] { "RetireeBenefitId", "BenefitId", "CoverageEndDate", "CoverageStartDate", "EnrolledAt", "IsActive", "RetireeId" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 },
                    { 2, 3, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1 },
                    { 3, 2, null, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2 },
                    { 4, 4, null, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2 },
                    { 5, 1, null, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { 6, 5, null, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 3 },
                    { 7, 2, null, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RetireeBenefits",
                keyColumn: "RetireeBenefitId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RetireeBenefits",
                keyColumn: "RetireeBenefitId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RetireeBenefits",
                keyColumn: "RetireeBenefitId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RetireeBenefits",
                keyColumn: "RetireeBenefitId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RetireeBenefits",
                keyColumn: "RetireeBenefitId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RetireeBenefits",
                keyColumn: "RetireeBenefitId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RetireeBenefits",
                keyColumn: "RetireeBenefitId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Benefits",
                keyColumn: "BenefitId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Benefits",
                keyColumn: "BenefitId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Benefits",
                keyColumn: "BenefitId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Benefits",
                keyColumn: "BenefitId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Benefits",
                keyColumn: "BenefitId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Retirees",
                keyColumn: "RetireeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Retirees",
                keyColumn: "RetireeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Retirees",
                keyColumn: "RetireeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Retirees",
                keyColumn: "RetireeId",
                keyValue: 4);
        }
    }
}
