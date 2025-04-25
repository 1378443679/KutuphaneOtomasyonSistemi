using System.ComponentModel.DataAnnotations;

namespace KutuphaneOtomasyonSistemi.Models
{
    public class Kitap : BaseEntity
    {
        [Key]
        public int KitapID { get; set; }

        public string? Başlık { get; set; } // Kitap Adı
        public string? Yazar { get; set; }
        public string? Yayıncı { get; set; }
        public string? ISBN { get; set; }
        public int YayınYılı { get; set; }
        public int SayfaSayısı { get; set; }

        // kategori ve kitap ilişkisi
        [Required]
        public int KategoriID { get; set; }
        public Kategori? Kategori { get; set; }
    }
}
