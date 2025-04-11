using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EMuhasebeWeb.Models
{
    public class Fatura
    {
        public int FaturaID { get; set; }

        [Required]
        public DateTime Tarih { get; set; }

        [Required]
        public int MusteriID { get; set; }
        public Musteri Musteri { get; set; }

        public int? KullaniciID { get; set; } // Faturayı kesen kullanıcı (muhasebeci vs.)
        public Kullanici? Kullanici { get; set; }

        public ICollection<FaturaDetay> FaturaDetaylari { get; set; }
        [Required]
        [Precision(18, 2)]
        public decimal ToplamTutar { get; set; }
    }
}
