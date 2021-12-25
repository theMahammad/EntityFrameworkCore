using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsingMigration.Migrations
{
    public partial class Bismillah : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Github");

            migrationBuilder.CreateTable(
                name: "OurAuthors",
                schema: "Github",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namee = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Agee = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurAuthors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Body = table.Column<string>(type: "ntext", nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "DateTime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_OurAuthors_AuthorId",
                        column: x => x.AuthorId,
                        principalSchema: "Github",
                        principalTable: "OurAuthors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "OurAuthors",
                schema: "Github");
        }
    }
}
