using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealer.Data.Migrations
{
    public partial class AddMetaDataTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MetaDataId",
                table: "Sales",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MetaData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleCityId = table.Column<int>(nullable: false),
                    CarModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetaData", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_MetaDataId",
                table: "Sales",
                column: "MetaDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_MetaData_MetaDataId",
                table: "Sales",
                column: "MetaDataId",
                principalTable: "MetaData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_MetaData_MetaDataId",
                table: "Sales");

            migrationBuilder.DropTable(
                name: "MetaData");

            migrationBuilder.DropIndex(
                name: "IX_Sales_MetaDataId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "MetaDataId",
                table: "Sales");
        }
    }
}
