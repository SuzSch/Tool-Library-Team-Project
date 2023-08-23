using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StuffSwapApi.Migrations
{
    public partial class MakeTool2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "ToolId", "ReturnDate", "ToolCategory", "ToolDescription", "ToolName", "ToolPhoto", "ToolStatus", "UserId" },
                values: new object[] { 2, "None", null, "Great gardening tools", "Gardening Tools", "www.photo.com/example2.png", "Available", 2 });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "ToolId", "ReturnDate", "ToolCategory", "ToolDescription", "ToolName", "ToolPhoto", "ToolStatus", "UserId" },
                values: new object[] { 3, "None", null, "A good climbing rope", "Rope for rock climbing", "www.photo.com/example3.png", "Available", 3 });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "ToolId", "ReturnDate", "ToolCategory", "ToolDescription", "ToolName", "ToolPhoto", "ToolStatus", "UserId" },
                values: new object[] { 4, "None", null, "Great Sprinkler", "Sprinkler", "www.photo.com/example4.png", "Available", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "ToolId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "ToolId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tools",
                keyColumn: "ToolId",
                keyValue: 4);
        }
    }
}
