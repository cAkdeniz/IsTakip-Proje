using Microsoft.EntityFrameworkCore.Migrations;

namespace IsTakipProject.DataAccess.Migrations
{
    public partial class AppUserGorevERManyWithOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Gorevler",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                maxLength: 30,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gorevler_AppUserId",
                table: "Gorevler",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gorevler_AspNetUsers_AppUserId",
                table: "Gorevler",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gorevler_AspNetUsers_AppUserId",
                table: "Gorevler");

            migrationBuilder.DropIndex(
                name: "IX_Gorevler_AppUserId",
                table: "Gorevler");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Gorevler");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");
        }
    }
}
