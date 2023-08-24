using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StuffSwapApi.Migrations
{
    public partial class AppUserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToolUsers_Users_UserId",
                table: "ToolUsers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ToolUsers",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ToolUsers_UserId",
                table: "ToolUsers",
                newName: "IX_ToolUsers_AppUserId");

            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserPassword = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserEmail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserPhoto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.AppUserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "AppUserId", "Address", "UserEmail", "UserName", "UserPassword", "UserPhoto" },
                values: new object[] { 1, null, null, "sampleUser@gmail.com", "samplePass", null });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "AppUserId", "Address", "UserEmail", "UserName", "UserPassword", "UserPhoto" },
                values: new object[] { 2, null, null, "taylor@gmail.com", "password", null });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "AppUserId", "Address", "UserEmail", "UserName", "UserPassword", "UserPhoto" },
                values: new object[] { 3, null, null, "coolguy@gmail.com", "password", null });

            migrationBuilder.AddForeignKey(
                name: "FK_ToolUsers_AppUsers_AppUserId",
                table: "ToolUsers",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToolUsers_AppUsers_AppUserId",
                table: "ToolUsers");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "ToolUsers",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ToolUsers_AppUserId",
                table: "ToolUsers",
                newName: "IX_ToolUsers_UserId");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserPhoto = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "Email", "Password", "UserName", "UserPhoto" },
                values: new object[] { 1, null, null, "samplePass", "sampleUser@gmail.com", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "Email", "Password", "UserName", "UserPhoto" },
                values: new object[] { 2, null, null, "password", "taylor@gmail.com", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "Email", "Password", "UserName", "UserPhoto" },
                values: new object[] { 3, null, null, "password", "coolguy@gmail.com", null });

            migrationBuilder.AddForeignKey(
                name: "FK_ToolUsers_Users_UserId",
                table: "ToolUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
