using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxCalculator.API.Data.Migrations
{
    public partial class changingPrgressiveTaxColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "ProgressiveTaxRates");

            migrationBuilder.DropColumn(
                name: "To",
                table: "ProgressiveTaxRates");

            migrationBuilder.AddColumn<int>(
                name: "HighBand",
                table: "ProgressiveTaxRates",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LowBand",
                table: "ProgressiveTaxRates",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighBand",
                table: "ProgressiveTaxRates");

            migrationBuilder.DropColumn(
                name: "LowBand",
                table: "ProgressiveTaxRates");

            migrationBuilder.AddColumn<int>(
                name: "From",
                table: "ProgressiveTaxRates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "To",
                table: "ProgressiveTaxRates",
                type: "int",
                nullable: true);
        }
    }
}
