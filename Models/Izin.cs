using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace KutuphaneOtomasyonSistemi.Models
{
    public class Izin : BaseEntity
    {
        [Key]
        public int IzinID { get; set; }

        // Rol tablosu ile ilişkilendirme
        [Required]
          public int RolID { get; set; }
          public Rol? Rol { get; set; }

        public string? SayfaAdı { get; set; }

        [Required]
        public ErisimTuru? ErisimTuru  { get; set; }
    }
}
