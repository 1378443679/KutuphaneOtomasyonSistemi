using System.ComponentModel.DataAnnotations;

namespace KutuphaneOtomasyonSistemi.Models
{
    public class Kullanıcı : BaseEntity
    {
        [Key]
        public int KullanıcıID { get; set; }

        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? Email { get; set; }
        public string? KullanıcıAdı { get; set; }
        public string? Şifre { get; set; }
        public string? TelefonNumarası { get; set; }
        public string? Adres { get; set; }
        
        // Rol tablosu ile Kullanıcı tablosunu ilişkilendirme
        [Required]
        public int RolID { get; set; }
        public Rol? Rol { get; set; }
        
    }
}
