using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangoRead.DAL.Migrations.ApplicationDb
{
    public partial class RenameMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsApproved",
                table: "Manuscripts",
                newName: "ApprovalStatus");

            migrationBuilder.RenameColumn(
                name: "ApprovingDate",
                table: "Manuscripts",
                newName: "ApprovalDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovalDate",
                table: "Reviews",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovalDate",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ApprovalStatus",
                table: "Manuscripts",
                newName: "IsApproved");

            migrationBuilder.RenameColumn(
                name: "ApprovalDate",
                table: "Manuscripts",
                newName: "ApprovingDate");
        }
    }
}
