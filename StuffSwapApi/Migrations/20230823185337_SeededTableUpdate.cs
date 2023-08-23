using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StuffSwapApi.Migrations
{
    public partial class SeededTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "ToolId",
                keyValue: 1,
                column: "ToolPhoto",
                value: "https://sgp1.digitaloceanspaces.com/fluxdigi/yourhousegarden/uploads/FI-best-weed-eater.jpg");

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "ToolId",
                keyValue: 2,
                columns: new[] { "ToolDescription", "ToolName", "ToolPhoto" },
                values: new object[] { "Used Size 7 Rollerskates", "Roller Skates", "https://s3-media0.fl.yelpcdn.com/bphoto/PBU2rkgpvKUrTVQyug0mfw/o.jpg" });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "ToolId",
                keyValue: 3,
                column: "ToolDescription",
                value: "A good climbing rope, only taken a few falls");

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "ToolId",
                keyValue: 4,
                columns: new[] { "ToolDescription", "ToolName", "ToolPhoto" },
                values: new object[] { "Kitchen Mixer with all attachemnts", "Kitchen Mixer", "https://i.ebayimg.com/images/g/vZ4AAOSwSm5f90tw/s-l500.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "ToolId",
                keyValue: 1,
                column: "ToolPhoto",
                value: "www.photo.com/example1.png");

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "ToolId",
                keyValue: 2,
                columns: new[] { "ToolDescription", "ToolName", "ToolPhoto" },
                values: new object[] { "Great gardening tools", "Gardening Tools", "www.photo.com/example2.png" });

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "ToolId",
                keyValue: 3,
                column: "ToolDescription",
                value: "A good climbing rope");

            migrationBuilder.UpdateData(
                table: "Tools",
                keyColumn: "ToolId",
                keyValue: 4,
                columns: new[] { "ToolDescription", "ToolName", "ToolPhoto" },
                values: new object[] { "Great Sprinkler", "Sprinkler", "www.photo.com/example4.png" });
        }
    }
}
