using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAnnotations_FluentAPI2.Migrations
{
    public partial class NamingColumnswithFluentAPI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "CustomizedName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomizedName",
                table: "Users",
                newName: "UserName");
        }
    }
}
