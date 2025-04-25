using KutuphaneOtomasyonSistemi.Models;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneOtomasyonSistemi.Repositories
{
    public class KitapContext : DbContext
    {
        public KitapContext(DbContextOptions<KitapContext> options)
            : base(options)
        {
        }

        public DbSet<Izin> Izinler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kullanıcı> Kullanıcılar { get; set; }
        public DbSet<Ödünç> Ödünçler { get; set; }
        public DbSet<Rezervasyon> Rezervasyonlar { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Üye> Üyeler { get; set; }
    }
}
