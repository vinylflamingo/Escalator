using Microsoft.EntityFrameworkCore.Migrations;

namespace EscalatorclassAPIEscalator.Migrations
{
    public partial class enumTicketType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ticketType",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ticketType",
                table: "Tickets");
        }
    }
}
