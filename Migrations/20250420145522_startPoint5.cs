using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutuphaneOtomasyonSistemi.Migrations
{
    public partial class startPoint5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kullanıcılar_Roller_RolId",
                table: "Kullanıcılar");

            migrationBuilder.RenameColumn(
                name: "RolId",
                table: "Kullanıcılar",
                newName: "RolID");

            migrationBuilder.RenameIndex(
                name: "IX_Kullanıcılar_RolId",
                table: "Kullanıcılar",
                newName: "IX_Kullanıcılar_RolID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanıcılar_Roller_RolID",
                table: "Kullanıcılar",
                column: "RolID",
                principalTable: "Roller",
                principalColumn: "RolID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kullanıcılar_Roller_RolID",
                table: "Kullanıcılar");

            migrationBuilder.RenameColumn(
                name: "RolID",
                table: "Kullanıcılar",
                newName: "RolId");

            migrationBuilder.RenameIndex(
                name: "IX_Kullanıcılar_RolID",
                table: "Kullanıcılar",
                newName: "IX_Kullanıcılar_RolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanıcılar_Roller_RolId",
                table: "Kullanıcılar",
                column: "RolId",
                principalTable: "Roller",
                principalColumn: "RolID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
