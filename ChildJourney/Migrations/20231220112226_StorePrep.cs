using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChildJourney.Migrations
{
    /// <inheritdoc />
    public partial class StorePrep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "UsersClothing",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "UsersBodyParts",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "UsersClothing");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "UsersBodyParts");
        }
    }
}
