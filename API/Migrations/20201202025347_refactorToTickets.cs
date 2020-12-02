using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EscalatorclassAPIEscalator.Migrations
{
    public partial class refactorToTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Escalations");

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    JurisdictionId = table.Column<long>(nullable: false),
                    AssignedAgent = table.Column<long>(nullable: false),
                    CompletedBy = table.Column<long>(nullable: false),
                    OpenDate = table.Column<DateTime>(nullable: false),
                    CloseDate = table.Column<DateTime>(nullable: false),
                    DueBy = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    OriginalAccount = table.Column<string>(nullable: true),
                    MoveToAccount = table.Column<string>(nullable: true),
                    Invoices = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.CreateTable(
                name: "Escalations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Account = table.Column<string>(type: "text", nullable: true),
                    AssignedAgent = table.Column<long>(type: "bigint", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CompletedBy = table.Column<long>(type: "bigint", nullable: false),
                    DueBy = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    JurisdictionId = table.Column<long>(type: "bigint", nullable: false),
                    OpenDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    details = table.Column<string>(type: "text", nullable: true),
                    emailAddress = table.Column<string>(type: "text", nullable: true),
                    phoneNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escalations", x => x.Id);
                });
        }
    }
}
