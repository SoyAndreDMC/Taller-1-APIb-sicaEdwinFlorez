using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddDBEmpleyees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clerks_FirstName",
                table: "Clerks");

            migrationBuilder.DropIndex(
                name: "IX_Clerks_LastName",
                table: "Clerks");

            migrationBuilder.CreateIndex(
                name: "IX_Clerks_FirstName_LastName",
                table: "Clerks",
                columns: new[] { "FirstName", "LastName" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clerks_FirstName_LastName",
                table: "Clerks");

            migrationBuilder.CreateIndex(
                name: "IX_Clerks_FirstName",
                table: "Clerks",
                column: "FirstName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clerks_LastName",
                table: "Clerks",
                column: "LastName",
                unique: true);
        }
    }
}
