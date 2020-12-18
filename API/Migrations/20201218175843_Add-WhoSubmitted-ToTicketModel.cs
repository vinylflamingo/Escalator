using Microsoft.EntityFrameworkCore.Migrations;

namespace EscalatorclassAPIEscalator.Migrations
{
    public partial class AddWhoSubmittedToTicketModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WhoSubmitted",
                table: "Tickets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhoSubmitted",
                table: "Tickets");
        }
    }
}
