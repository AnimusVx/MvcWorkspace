using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcWorkspace.Migrations
{
    public partial class BolumID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bolums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bolums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "personels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Test = table.Column<int>(type: "int", nullable: false),
                    BolumID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personels_bolums_BolumID",
                        column: x => x.BolumID,
                        principalTable: "bolums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_personels_BolumID",
                table: "personels",
                column: "BolumID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personels");

            migrationBuilder.DropTable(
                name: "bolums");
        }
    }
}
