using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KutuphaneOtomasyonSistemi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OluşturmaZamanı = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GüncellenmeZamanı = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolAdı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OluşturmaZamanı = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GüncellenmeZamanı = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "Üyeler",
                columns: table => new
                {
                    ÜyeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TCKimlikNo = table.Column<int>(type: "int", nullable: false),
                    TelefonNo = table.Column<int>(type: "int", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OluşturmaZamanı = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GüncellenmeZamanı = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Üyeler", x => x.ÜyeID);
                });

            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    KitapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Başlık = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yazar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yayıncı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBN = table.Column<int>(type: "int", nullable: false),
                    YayınYılı = table.Column<int>(type: "int", nullable: false),
                    SayfaSayısı = table.Column<int>(type: "int", nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: true),
                    OluşturmaZamanı = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GüncellenmeZamanı = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.KitapID);
                    table.ForeignKey(
                        name: "FK_Kitaplar_Kategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriID");
                });

            migrationBuilder.CreateTable(
                name: "İzinler",
                columns: table => new
                {
                    IzinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolID = table.Column<int>(type: "int", nullable: false),
                    SayfaAdı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OluşturmaZamanı = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GüncellenmeZamanı = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İzinler", x => x.IzinID);
                    table.ForeignKey(
                        name: "FK_İzinler_Roller_RolID",
                        column: x => x.RolID,
                        principalTable: "Roller",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kullanıcılar",
                columns: table => new
                {
                    KullanıcıID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KullanıcıAdı = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Şifre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonNumarası = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    OluşturmaZamanı = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GüncellenmeZamanı = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcılar", x => x.KullanıcıID);
                    table.ForeignKey(
                        name: "FK_Kullanıcılar_Roller_RolId",
                        column: x => x.RolId,
                        principalTable: "Roller",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ödünçler",
                columns: table => new
                {
                    KitapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ÜyeID = table.Column<int>(type: "int", nullable: false),
                    İadeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ödünçler", x => x.KitapID);
                    table.ForeignKey(
                        name: "FK_Ödünçler_Üyeler_ÜyeID",
                        column: x => x.ÜyeID,
                        principalTable: "Üyeler",
                        principalColumn: "ÜyeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervasyonlar",
                columns: table => new
                {
                    RezervasyonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullanıcıID = table.Column<int>(type: "int", nullable: false),
                    KitapID = table.Column<int>(type: "int", nullable: false),
                    RezervasyonTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GeçerlilikSüresi = table.Column<int>(type: "int", nullable: false),
                    OluşturmaZamanı = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GüncellenmeZamanı = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervasyonlar", x => x.RezervasyonID);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Kitaplar_KitapID",
                        column: x => x.KitapID,
                        principalTable: "Kitaplar",
                        principalColumn: "KitapID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Kullanıcılar_KullanıcıID",
                        column: x => x.KullanıcıID,
                        principalTable: "Kullanıcılar",
                        principalColumn: "KullanıcıID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_İzinler_RolID",
                table: "İzinler",
                column: "RolID");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_KategoriID",
                table: "Kitaplar",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanıcılar_RolId",
                table: "Kullanıcılar",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Ödünçler_ÜyeID",
                table: "Ödünçler",
                column: "ÜyeID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_KitapID",
                table: "Rezervasyonlar",
                column: "KitapID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_KullanıcıID",
                table: "Rezervasyonlar",
                column: "KullanıcıID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "İzinler");

            migrationBuilder.DropTable(
                name: "Ödünçler");

            migrationBuilder.DropTable(
                name: "Rezervasyonlar");

            migrationBuilder.DropTable(
                name: "Üyeler");

            migrationBuilder.DropTable(
                name: "Kitaplar");

            migrationBuilder.DropTable(
                name: "Kullanıcılar");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Roller");
        }
    }
}
