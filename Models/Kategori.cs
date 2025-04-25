namespace KutuphaneOtomasyonSistemi.Models
{
    public class Kategori : BaseEntity
    {
        public int KategoriID { get; set; }
        public string? KategoriAdı { get; set; }
        public ICollection<Kitap>? Kitaplar { get; set; }
    }
}
