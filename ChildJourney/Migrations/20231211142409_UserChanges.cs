using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChildJourney.Migrations
{
    /// <inheritdoc />
    public partial class UserChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Decoration_OwnedHouseId",
                table: "Animals");

            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "longtext",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Rewards",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OwnedHouseId",
                table: "Animals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Decoration_OwnedHouseId",
                table: "Animals",
                column: "OwnedHouseId",
                principalTable: "Decoration",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Decoration_OwnedHouseId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Admin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "Rewards",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<int>(
                name: "OwnedHouseId",
                table: "Animals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Decoration_OwnedHouseId",
                table: "Animals",
                column: "OwnedHouseId",
                principalTable: "Decoration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
