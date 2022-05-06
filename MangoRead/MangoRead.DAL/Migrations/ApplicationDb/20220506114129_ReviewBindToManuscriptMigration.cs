using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangoRead.DAL.Migrations.ApplicationDb
{
    public partial class ReviewBindToManuscriptMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManuscriptId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ManuscriptId",
                table: "Reviews",
                column: "ManuscriptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Manuscripts_ManuscriptId",
                table: "Reviews",
                column: "ManuscriptId",
                principalTable: "Manuscripts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Manuscripts_ManuscriptId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ManuscriptId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ManuscriptId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Reviews");
        }
    }
}
