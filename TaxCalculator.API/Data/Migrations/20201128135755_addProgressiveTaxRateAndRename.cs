using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxCalculator.API.Data.Migrations
{
    public partial class addProgressiveTaxRateAndRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaTax_TaxType_TaxTypeID",
                table: "AreaTax");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxType",
                table: "TaxType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AreaTax",
                table: "AreaTax");

            migrationBuilder.RenameTable(
                name: "TaxType",
                newName: "TaxTypes");

            migrationBuilder.RenameTable(
                name: "AreaTax",
                newName: "AreaTaxes");

            migrationBuilder.RenameIndex(
                name: "IX_AreaTax_TaxTypeID",
                table: "AreaTaxes",
                newName: "IX_AreaTaxes_TaxTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxTypes",
                table: "TaxTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AreaTaxes",
                table: "AreaTaxes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProgressiveTaxRates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<decimal>(nullable: false),
                    From = table.Column<int>(nullable: false),
                    To = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressiveTaxRates", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AreaTaxes_TaxTypes_TaxTypeID",
                table: "AreaTaxes",
                column: "TaxTypeID",
                principalTable: "TaxTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaTaxes_TaxTypes_TaxTypeID",
                table: "AreaTaxes");

            migrationBuilder.DropTable(
                name: "ProgressiveTaxRates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxTypes",
                table: "TaxTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AreaTaxes",
                table: "AreaTaxes");

            migrationBuilder.RenameTable(
                name: "TaxTypes",
                newName: "TaxType");

            migrationBuilder.RenameTable(
                name: "AreaTaxes",
                newName: "AreaTax");

            migrationBuilder.RenameIndex(
                name: "IX_AreaTaxes_TaxTypeID",
                table: "AreaTax",
                newName: "IX_AreaTax_TaxTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxType",
                table: "TaxType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AreaTax",
                table: "AreaTax",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaTax_TaxType_TaxTypeID",
                table: "AreaTax",
                column: "TaxTypeID",
                principalTable: "TaxType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
