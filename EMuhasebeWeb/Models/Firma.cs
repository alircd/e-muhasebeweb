using System.ComponentModel.DataAnnotations;

namespace EMuhasebeWeb.Models
{
    public class Firma
    {
        public int FirmaID { get; set; }

        [Required]
        public string Unvan { get; set; }

        public string? VergiNo { get; set; }

        public string? Telefon { get; set; }

        public string? Email { get; set; }

        public string? Adres { get; set; }

        public string? LogoUrl { get; set; } // logo dosya adı veya linki
    }
}
