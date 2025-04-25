using System.ComponentModel.DataAnnotations;

namespace KutuphaneOtomasyonSistemi.Models
{
    public class Rol : BaseEntity
    {
        [Key]
        public int RolID { get; set; }

        public string? RolAdı { get; set; }
        public ICollection<Kullanıcı>? Kullanıcılar { get; set; }
    }
}
