using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutuphaneOtomasyonSistemi.Migrations
{
    public partial class startPoint6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ödünçler",
                table: "Ödünçler");

            migrationBuilder.AlterColumn<int>(
                name: "KitapID",
                table: "Ödünçler",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ÖdünçID",
                table: "Ödünçler",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Durum",
                table: "Ödünçler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GüncellenmeZamanı",
                table: "Ödünçler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OluşturmaZamanı",
                table: "Ödünçler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ödünçler",
                table: "Ödünçler",
                column: "ÖdünçID");

            migrationBuilder.CreateIndex(
                name: "IX_Ödünçler_KitapID",
                table: "Ödünçler",
                column: "KitapID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ödünçler_Kitaplar_KitapID",
                table: "Ödünçler",
                column: "KitapID",
                principalTable: "Kitaplar",
                principalColumn: "KitapID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ödünçler_Kitaplar_KitapID",
                table: "Ödünçler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ödünçler",
                table: "Ödünçler");

            migrationBuilder.DropIndex(
                name: "IX_Ödünçler_KitapID",
                table: "Ödünçler");

            migrationBuilder.DropColumn(
                name: "ÖdünçID",
                table: "Ödünçler");

            migrationBuilder.DropColumn(
                name: "Durum",
                table: "Ödünçler");

            migrationBuilder.DropColumn(
                name: "GüncellenmeZamanı",
                table: "Ödünçler");

            migrationBuilder.DropColumn(
                name: "OluşturmaZamanı",
                table: "Ödünçler");

            migrationBuilder.AlterColumn<int>(
                name: "KitapID",
                table: "Ödünçler",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ödünçler",
                table: "Ödünçler",
                column: "KitapID");
        }
    }
}
