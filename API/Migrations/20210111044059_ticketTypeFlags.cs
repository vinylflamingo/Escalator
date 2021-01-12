using Microsoft.EntityFrameworkCore.Migrations;

namespace EscalatorclassAPI.Migrations
{
    public partial class ticketTypeFlags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "formAssignedAgent",
                table: "TicketType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "formCompletedBy",
                table: "TicketType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "formDetails",
                table: "TicketType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "formDueDate",
                table: "TicketType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "formEmailAddress",
                table: "TicketType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "formInvoices",
                table: "TicketType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "formJurisdiction",
                table: "TicketType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "formMarkComplete",
                table: "TicketType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "formMoveToAccount",
                table: "TicketType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "formOriginalAccount",
                table: "TicketType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "formPhoneNumber",
                table: "TicketType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "formSeverity",
                table: "TicketType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "formStatus",
                table: "TicketType",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "formAssignedAgent",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "formCompletedBy",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "formDetails",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "formDueDate",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "formEmailAddress",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "formInvoices",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "formJurisdiction",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "formMarkComplete",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "formMoveToAccount",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "formOriginalAccount",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "formPhoneNumber",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "formSeverity",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "formStatus",
                table: "TicketType");
        }
    }
}
