using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxCalculator.API.Data.Migrations
{
    public partial class refnamechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxType_PostalCode_Ref",
                table: "TaxType_PostalCode_Ref");

            migrationBuilder.RenameTable(
                name: "TaxType_PostalCode_Ref",
                newName: "TaxType_PostalCode_Refs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxType_PostalCode_Refs",
                table: "TaxType_PostalCode_Refs",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxType_PostalCode_Refs",
                table: "TaxType_PostalCode_Refs");

            migrationBuilder.RenameTable(
                name: "TaxType_PostalCode_Refs",
                newName: "TaxType_PostalCode_Ref");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxType_PostalCode_Ref",
                table: "TaxType_PostalCode_Ref",
                column: "Id");
        }
    }
}
