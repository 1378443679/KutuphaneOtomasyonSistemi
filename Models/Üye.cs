namespace KutuphaneOtomasyonSistemi.Models
{
    public class Üye : BaseEntity
    {
        public int ÜyeID { get; set; }
        public int TCKimlikNo { get; set; }
        public int TelefonNo { get; set; }
        public string? Eposta { get; set; }
        public string? Adres { get; set; }
    }
}
