using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EMuhasebeWeb.Models
{
    public class GelirGider
    {
        public int GelirGiderID { get; set; }

        [Required]
        public string Aciklama { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal Tutar { get; set; }

        [Required]
        public DateTime Tarih { get; set; }

        [Required]
        public bool IsGelir { get; set; } // true = gelir, false = gider

        public int? KullaniciID { get; set; } // işlemi yapan kullanıcı (opsiyonel)
        public Kullanici? Kullanici { get; set; }
    }
}
