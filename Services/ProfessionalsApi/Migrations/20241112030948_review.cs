using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProfessionalsApi.Migrations
{
    /// <inheritdoc />
    public partial class review : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CummilativeRating",
                table: "Professionals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "TotalReviews",
                table: "Professionals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CummilativeRating",
                table: "Professionals");

            migrationBuilder.DropColumn(
                name: "TotalReviews",
                table: "Professionals");
        }
    }
}
