using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAnnotations_FluentAPI2.Migrations
{
    public partial class ElaboratingTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityNumber",
                table: "Users",
                type: "nvarchar(25)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityNumber",
                table: "Users");
        }
    }
}
