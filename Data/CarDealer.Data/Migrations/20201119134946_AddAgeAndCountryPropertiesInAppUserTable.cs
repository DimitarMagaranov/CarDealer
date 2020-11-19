using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealer.Data.Migrations
{
    public partial class AddAgeAndCountryPropertiesInAppUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_MetaData_MetaDataId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MetaData",
                table: "MetaData");

            migrationBuilder.RenameTable(
                name: "MetaData",
                newName: "MetaDatas");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MetaDatas",
                table: "MetaDatas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Countries_CountryId",
                table: "AspNetUsers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_MetaDatas_MetaDataId",
                table: "Sales",
                column: "MetaDataId",
                principalTable: "MetaDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Countries_CountryId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_MetaDatas_MetaDataId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CountryId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MetaDatas",
                table: "MetaDatas");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "MetaDatas",
                newName: "MetaData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MetaData",
                table: "MetaData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_MetaData_MetaDataId",
                table: "Sales",
                column: "MetaDataId",
                principalTable: "MetaData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
