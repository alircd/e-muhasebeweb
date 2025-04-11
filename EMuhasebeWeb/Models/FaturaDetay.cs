using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EMuhasebeWeb.Models
{
    public class FaturaDetay
    {
        public int FaturaDetayID { get; set; }

        [Required]
        public int FaturaID { get; set; }
        public Fatura Fatura { get; set; }

        [Required]
        public int UrunID { get; set; }
        public Urun Urun { get; set; }

        [Required]
        public int Adet { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal BirimFiyat { get; set; }

        public decimal AraToplam => Adet * BirimFiyat;
    }
}
