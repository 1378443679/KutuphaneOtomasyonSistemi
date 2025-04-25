using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutuphaneOtomasyonSistemi.Migrations
{
    public partial class AddErisimTuruColumnToIzinler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ErisimTuru",
                table: "İzinler",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErisimTuru",
                table: "İzinler");
        }
    }
}
