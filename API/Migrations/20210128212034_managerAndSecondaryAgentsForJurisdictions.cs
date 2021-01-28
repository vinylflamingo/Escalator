using Microsoft.EntityFrameworkCore.Migrations;

namespace EscalatorclassAPI.Migrations
{
    public partial class managerAndSecondaryAgentsForJurisdictions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DefaultManagerId",
                table: "Jurisdictions",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SecondaryAgentId",
                table: "Jurisdictions",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TertiaryAgentId",
                table: "Jurisdictions",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultManagerId",
                table: "Jurisdictions");

            migrationBuilder.DropColumn(
                name: "SecondaryAgentId",
                table: "Jurisdictions");

            migrationBuilder.DropColumn(
                name: "TertiaryAgentId",
                table: "Jurisdictions");
        }
    }
}
