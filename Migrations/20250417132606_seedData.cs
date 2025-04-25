using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutuphaneOtomasyonSistemi.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitaplar_Kategoriler_KategoriID",
                table: "Kitaplar");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriID",
                table: "Kitaplar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Kitaplar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitaplar_Kategoriler_KategoriID",
                table: "Kitaplar",
                column: "KategoriID",
                principalTable: "Kategoriler",
                principalColumn: "KategoriID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitaplar_Kategoriler_KategoriID",
                table: "Kitaplar");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriID",
                table: "Kitaplar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ISBN",
                table: "Kitaplar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kitaplar_Kategoriler_KategoriID",
                table: "Kitaplar",
                column: "KategoriID",
                principalTable: "Kategoriler",
                principalColumn: "KategoriID");
        }
    }
}
