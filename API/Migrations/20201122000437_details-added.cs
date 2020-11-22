using Microsoft.EntityFrameworkCore.Migrations;

namespace CW_Escalate.Migrations
{
    public partial class detailsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "details",
                table: "Escalations",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "details",
                table: "Escalations");
        }
    }
}
