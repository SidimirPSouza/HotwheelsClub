using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotwheelsClub.Migrations
{
    public partial class AddClub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "MonthlyFees",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ClubModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProprietorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_ClubId",
                table: "User",
                column: "ClubId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ClubModel_ClubId",
                table: "User",
                column: "ClubId",
                principalTable: "ClubModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_ClubModel_ClubId",
                table: "User");

            migrationBuilder.DropTable(
                name: "ClubModel");

            migrationBuilder.DropIndex(
                name: "IX_User_ClubId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "MonthlyFees",
                table: "User");
        }
    }
}
