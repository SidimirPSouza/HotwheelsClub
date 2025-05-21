using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotwheelsClub.Migrations
{
    public partial class CleanSetNullFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProprietorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MonthlyFees = table.Column<bool>(type: "bit", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull); // Ajuste aqui
                });

            migrationBuilder.CreateTable(
                name: "Hotwheels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ProprietorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotwheels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotwheels_User_ProprietorId",
                        column: x => x.ProprietorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Índices
            migrationBuilder.CreateIndex(
                name: "IX_Club_ProprietorId",
                table: "Club",
                column: "ProprietorId");

            migrationBuilder.CreateIndex(
                name: "IX_User_ClubId",
                table: "User",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotwheels_ProprietorId",
                table: "Hotwheels",
                column: "ProprietorId");

            // Adicionar a FK para ProprietorId aqui, depois da User já existir
            migrationBuilder.AddForeignKey(
                name: "FK_Club_User_ProprietorId",
                table: "Club",
                column: "ProprietorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull); // Evita múltiplos cascades
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Club_User_ProprietorId",
                table: "Club");

            migrationBuilder.DropTable(
                name: "Hotwheels");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Club");
        }
    }
}
