using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChildJourney.Migrations
{
    /// <inheritdoc />
    public partial class SmallAdditionImagetoIsland : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Islands",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Islands");
        }
    }
}
