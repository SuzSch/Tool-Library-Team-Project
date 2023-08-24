using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StuffSwapApi.Migrations
{
    public partial class AppUserIdTool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tools",
                newName: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Tools",
                newName: "UserId");
        }
    }
}
