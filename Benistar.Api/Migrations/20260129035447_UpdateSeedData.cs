using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Benistar.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Retirees",
                keyColumn: "RetireeId",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "anurag.varma@benistar.com", "Anurag", "Varma" });

            migrationBuilder.UpdateData(
                table: "Retirees",
                keyColumn: "RetireeId",
                keyValue: 2,
                columns: new[] { "Email", "FirstName" },
                values: new object[] { "mark.johnson@benistar.com", "Mark" });

            migrationBuilder.UpdateData(
                table: "Retirees",
                keyColumn: "RetireeId",
                keyValue: 3,
                column: "Email",
                value: "robert.williams@benistar.com");

            migrationBuilder.UpdateData(
                table: "Retirees",
                keyColumn: "RetireeId",
                keyValue: 4,
                column: "Email",
                value: "patricia.brown@benistar.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Retirees",
                keyColumn: "RetireeId",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "john.smith@email.com", "John", "Smith" });

            migrationBuilder.UpdateData(
                table: "Retirees",
                keyColumn: "RetireeId",
                keyValue: 2,
                columns: new[] { "Email", "FirstName" },
                values: new object[] { "mary.johnson@email.com", "Mary" });

            migrationBuilder.UpdateData(
                table: "Retirees",
                keyColumn: "RetireeId",
                keyValue: 3,
                column: "Email",
                value: "robert.williams@email.com");

            migrationBuilder.UpdateData(
                table: "Retirees",
                keyColumn: "RetireeId",
                keyValue: 4,
                column: "Email",
                value: "patricia.brown@email.com");
        }
    }
}
