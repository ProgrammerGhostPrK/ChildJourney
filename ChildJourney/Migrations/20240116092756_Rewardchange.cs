using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChildJourney.Migrations
{
    /// <inheritdoc />
    public partial class Rewardchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "Rewards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Rewards");
        }
    }
}
