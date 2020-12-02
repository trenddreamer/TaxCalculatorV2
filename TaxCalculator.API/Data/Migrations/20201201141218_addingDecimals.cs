using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxCalculator.API.Data.Migrations
{
    public partial class addingDecimals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TaxAmount",
                table: "TaxResults",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "TaxResults",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "ProgressiveTaxRates",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "IX_TaxType_PostalCode_Refs_TaxTypeID",
                table: "TaxType_PostalCode_Refs",
                column: "TaxTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxType_PostalCode_Refs_TaxTypes_TaxTypeID",
                table: "TaxType_PostalCode_Refs",
                column: "TaxTypeID",
                principalTable: "TaxTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxType_PostalCode_Refs_TaxTypes_TaxTypeID",
                table: "TaxType_PostalCode_Refs");

            migrationBuilder.DropIndex(
                name: "IX_TaxType_PostalCode_Refs_TaxTypeID",
                table: "TaxType_PostalCode_Refs");

            migrationBuilder.AlterColumn<int>(
                name: "TaxAmount",
                table: "TaxResults",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "TaxResults",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<double>(
                name: "Rate",
                table: "ProgressiveTaxRates",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
