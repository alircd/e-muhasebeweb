using System.ComponentModel.DataAnnotations;

namespace EMuhasebeWeb.Models
{
    public class Musteri
    {
        public int MusteriID { get; set; }

        [Required]
        public string AdSoyad { get; set; }

        public string? Telefon { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Adres { get; set; }

        public ICollection<Fatura> Faturalar { get; set; }
        public ICollection<Odeme> Odemeler { get; set; }
    }
}
