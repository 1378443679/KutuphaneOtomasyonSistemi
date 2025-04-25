namespace KutuphaneOtomasyonSistemi.Models
{
    public class BaseEntity 
    {
        public DateTime OluşturmaZamanı { get; set; }  = DateTime.Now;
        public DateTime GüncellenmeZamanı { get; set; } = DateTime.Now;
        public string? Durum { get; set; }
    }
}
