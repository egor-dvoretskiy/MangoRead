using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangoRead.DAL.Migrations.ApplicationDb
{
    public partial class ApproveMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovingDate",
                table: "Manuscripts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Manuscripts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovingDate",
                table: "Manuscripts");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Manuscripts");
        }
    }
}
