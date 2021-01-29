using Microsoft.EntityFrameworkCore.Migrations;

namespace EscalatorclassAPI.Migrations
{
    public partial class OptInForEmail2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OptInNotifications",
                table: "Agents",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OptInReports",
                table: "Agents",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OptInNotifications",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "OptInReports",
                table: "Agents");
        }
    }
}
