using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutuphaneOtomasyonSistemi.Migrations
{
    public partial class startPoint7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IzinID",
                table: "İzinler",
                newName: "İzinID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "İzinID",
                table: "İzinler",
                newName: "IzinID");
        }
    }
}
