using Microsoft.EntityFrameworkCore.Migrations;

namespace UsingMigration.Migrations
{
    public partial class addColumnWorkExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "WorkExperience",
                schema: "Github",
                table: "OurAuthors",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkExperience",
                schema: "Github",
                table: "OurAuthors");
        }
    }
}
