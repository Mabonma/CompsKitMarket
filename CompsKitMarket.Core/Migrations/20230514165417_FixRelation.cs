using Microsoft.EntityFrameworkCore.Migrations;

namespace CompsKitMarket.Core.Migrations
{
    public partial class FixRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManufacturerPart");

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerID",
                table: "Parts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Parts_ManufacturerID",
                table: "Parts",
                column: "ManufacturerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Manufacturers_ManufacturerID",
                table: "Parts",
                column: "ManufacturerID",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Manufacturers_ManufacturerID",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_Parts_ManufacturerID",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "ManufacturerID",
                table: "Parts");

            migrationBuilder.CreateTable(
                name: "ManufacturerPart",
                columns: table => new
                {
                    ManufacturersId = table.Column<int>(type: "int", nullable: false),
                    PartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturerPart", x => new { x.ManufacturersId, x.PartsId });
                    table.ForeignKey(
                        name: "FK_ManufacturerPart_Manufacturers_ManufacturersId",
                        column: x => x.ManufacturersId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManufacturerPart_Parts_PartsId",
                        column: x => x.PartsId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturerPart_PartsId",
                table: "ManufacturerPart",
                column: "PartsId");
        }
    }
}
