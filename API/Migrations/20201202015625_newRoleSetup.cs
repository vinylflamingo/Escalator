﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace EscalatorclassAPIEscalator.Migrations
{
    public partial class newRoleSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "roles",
                table: "Agents");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Agents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Agents");

            migrationBuilder.AddColumn<string>(
                name: "roles",
                table: "Agents",
                type: "text",
                nullable: true);
        }
    }
}