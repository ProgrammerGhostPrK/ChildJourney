using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChildJourney.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHouseDeco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Decoration_Houses_HouseId",
                table: "Decoration");

            migrationBuilder.DropIndex(
                name: "IX_Decoration_HouseId",
                table: "Decoration");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "Decoration");

            migrationBuilder.AddColumn<int>(
                name: "HouseId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HouseDecorations",
                columns: table => new
                {
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    HousePartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseDecorations", x => new { x.HouseId, x.HousePartsId });
                    table.ForeignKey(
                        name: "FK_HouseDecorations_Decoration_HousePartsId",
                        column: x => x.HousePartsId,
                        principalTable: "Decoration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseDecorations_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_HouseDecorations_HousePartsId",
                table: "HouseDecorations",
                column: "HousePartsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseDecorations");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "HouseId",
                table: "Decoration",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Decoration_HouseId",
                table: "Decoration",
                column: "HouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Decoration_Houses_HouseId",
                table: "Decoration",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id");
        }
    }
}
