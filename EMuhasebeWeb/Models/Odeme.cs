using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace EMuhasebeWeb.Models
{
    public class Odeme
    {
        public int OdemeID { get; set; }

        [Required]
        public int MusteriID { get; set; }
        public Musteri Musteri { get; set; }

        public int? FaturaID { get; set; } //Fatura ile ilişkili
        public Fatura? Fatura { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal Tutar { get; set; }

        [Required]
        public DateTime Tarih { get; set; }

        public string? Aciklama { get; set; }
    }
}
