using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangoRead.DAL.Migrations.ApplicationDb
{
    public partial class NumbersContentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VolumeNumber",
                table: "Volume",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PageNumber",
                table: "Page",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChapterNumber",
                table: "Chapter",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VolumeNumber",
                table: "Volume");

            migrationBuilder.DropColumn(
                name: "PageNumber",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "ChapterNumber",
                table: "Chapter");
        }
    }
}
