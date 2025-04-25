using System.ComponentModel.DataAnnotations;

namespace KutuphaneOtomasyonSistemi.Models
{
    public class Ödünç : BaseEntity
    {
        [Key]
        public int ÖdünçID { get; set; }
        
        // Kitap tablosu ile Ödünç tablosu ilişkisi
        [Required]
        public int KitapID { get; set; }
        public Kitap? Kitap { get; set; }

        // Üye tablosu ile Ödünç tablosu ilişkisi
        [Required]
        public int ÜyeID { get; set; }
        public Üye? Üye { get; set; }

        public DateTime İadeTarihi { get; set; }
    }
}
