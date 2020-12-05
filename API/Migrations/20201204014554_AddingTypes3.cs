using Microsoft.EntityFrameworkCore.Migrations;

namespace EscalatorclassAPIEscalator.Migrations
{
    public partial class AddingTypes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketType_ticketTypeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ticketTypeId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ticketTypeId",
                table: "Tickets");

            migrationBuilder.AddColumn<long>(
                name: "ticketType",
                table: "Tickets",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ticketType",
                table: "Tickets");

            migrationBuilder.AddColumn<long>(
                name: "ticketTypeId",
                table: "Tickets",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ticketTypeId",
                table: "Tickets",
                column: "ticketTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketType_ticketTypeId",
                table: "Tickets",
                column: "ticketTypeId",
                principalTable: "TicketType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
