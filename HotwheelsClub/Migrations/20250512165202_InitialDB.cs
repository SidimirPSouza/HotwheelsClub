using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotwheelsClub.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotwheels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    preco = table.Column<double>(type: "float", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    DonoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotwheels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotwheels_Usuarios_DonoId",
                        column: x => x.DonoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotwheels_DonoId",
                table: "Hotwheels",
                column: "DonoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotwheels");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
