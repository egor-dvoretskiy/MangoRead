using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangoRead.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manuscripts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Translator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRequireLegalAge = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manuscripts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreHolder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genre = table.Column<int>(type: "int", nullable: false),
                    ManuscriptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreHolder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenreHolder_Manuscripts_ManuscriptId",
                        column: x => x.ManuscriptId,
                        principalTable: "Manuscripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManuscriptContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FolderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PagesAmount = table.Column<int>(type: "int", nullable: false),
                    ManuscriptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManuscriptContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManuscriptContent_Manuscripts_ManuscriptId",
                        column: x => x.ManuscriptId,
                        principalTable: "Manuscripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManuscriptContentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Page_ManuscriptContent_ManuscriptContentId",
                        column: x => x.ManuscriptContentId,
                        principalTable: "ManuscriptContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreHolder_ManuscriptId",
                table: "GenreHolder",
                column: "ManuscriptId");

            migrationBuilder.CreateIndex(
                name: "IX_ManuscriptContent_ManuscriptId",
                table: "ManuscriptContent",
                column: "ManuscriptId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manuscripts_Index",
                table: "Manuscripts",
                column: "Index");

            migrationBuilder.CreateIndex(
                name: "IX_Page_ManuscriptContentId",
                table: "Page",
                column: "ManuscriptContentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreHolder");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "ManuscriptContent");

            migrationBuilder.DropTable(
                name: "Manuscripts");
        }
    }
}
