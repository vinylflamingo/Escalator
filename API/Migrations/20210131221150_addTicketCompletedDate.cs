using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EscalatorclassAPI.Migrations
{
    public partial class addTicketCompletedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedDate",
                table: "Tickets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedDate",
                table: "Tickets");
        }
    }
}
