using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StuffSwapApi.Migrations
{
    public partial class MakeTool1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "ToolId", "ReturnDate", "ToolCategory", "ToolDescription", "ToolName", "ToolPhoto", "ToolStatus", "UserId" },
                values: new object[] { 1, "None", null, "A good weedwacker", "Weedwacker", "www.photo.com/example1.png", "Available", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "ToolId",
                keyValue: 1);
        }
    }
}
