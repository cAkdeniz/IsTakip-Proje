using Microsoft.EntityFrameworkCore.Migrations;

namespace IsTakipProject.DataAccess.Migrations
{
    public partial class CreateTableRapor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Raporlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tanim = table.Column<string>(maxLength: 100, nullable: false),
                    Detay = table.Column<string>(type: "ntext", nullable: true),
                    GorevId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raporlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Raporlar_Gorevler_GorevId",
                        column: x => x.GorevId,
                        principalTable: "Gorevler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Raporlar_GorevId",
                table: "Raporlar",
                column: "GorevId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Raporlar");
        }
    }
}
