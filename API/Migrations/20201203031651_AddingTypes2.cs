using Microsoft.EntityFrameworkCore.Migrations;

namespace EscalatorclassAPIEscalator.Migrations
{
    public partial class AddingTypes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_TicketType_TypeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TypeId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Tickets");

            migrationBuilder.AddColumn<long>(
                name: "ticketTypeId",
                table: "Tickets",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "TypeId",
                table: "Tickets",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TypeId",
                table: "Tickets",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_TicketType_TypeId",
                table: "Tickets",
                column: "TypeId",
                principalTable: "TicketType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
