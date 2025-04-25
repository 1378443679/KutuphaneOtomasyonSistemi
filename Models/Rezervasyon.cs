using System.ComponentModel.DataAnnotations;

namespace KutuphaneOtomasyonSistemi.Models
{
    public class Rezervasyon : BaseEntity
    {
        [Key]
        public int RezervasyonID { get; set; }

        // Kullanıcı tablosu ilişkisel alan 
        [Required]
        public int KullanıcıID { get; set; }
        public Kullanıcı? Kullanıcı { get; set; }

        // Kitap tablosu ilişkisel alan 
        [Required]
        public int KitapID { get; set; }
        public Kitap? Kitap { get; set; }
        
        [Required]
        public DateTime RezervasyonTarihi { get; set; }
        public int GeçerlilikSüresi { get; set; } // örn. gün cinsinden
    }
}
