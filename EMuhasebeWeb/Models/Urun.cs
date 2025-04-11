using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EMuhasebeWeb.Models
{
    public class Urun
    {
        public int UrunID { get; set; }

        [Required]
        public string Ad { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal Fiyat { get; set; }

        public int? KategoriID { get; set; }
        public Kategori? Kategori { get; set; }

        public ICollection<FaturaDetay> FaturaDetaylari { get; set; }
    }
}
