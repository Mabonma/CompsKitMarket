using Microsoft.EntityFrameworkCore.Migrations;

namespace CompsKitMarket.Core.Migrations
{
    public partial class FixRelationImagePart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagePart");

            migrationBuilder.AddColumn<int>(
                name: "PartId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_PartId",
                table: "Images",
                column: "PartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Parts_PartId",
                table: "Images",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Parts_PartId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_PartId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "PartId",
                table: "Images");

            migrationBuilder.CreateTable(
                name: "ImagePart",
                columns: table => new
                {
                    ImagesId = table.Column<int>(type: "int", nullable: false),
                    PartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagePart", x => new { x.ImagesId, x.PartsId });
                    table.ForeignKey(
                        name: "FK_ImagePart_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImagePart_Parts_PartsId",
                        column: x => x.PartsId,
                        principalTable: "Parts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagePart_PartsId",
                table: "ImagePart",
                column: "PartsId");
        }
    }
}
