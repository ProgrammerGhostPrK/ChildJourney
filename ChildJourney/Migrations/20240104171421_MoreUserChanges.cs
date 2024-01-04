using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChildJourney.Migrations
{
    /// <inheritdoc />
    public partial class MoreUserChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "lastlogin",
                table: "Users",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lastlogin",
                table: "Users");
        }
    }
}
