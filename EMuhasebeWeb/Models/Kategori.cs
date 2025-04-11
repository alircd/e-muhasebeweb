using System.ComponentModel.DataAnnotations;

namespace EMuhasebeWeb.Models
{
    public class Kategori
    {
        public int KategoriID { get; set; }

        [Required]
        public string Ad { get; set; }

        public string? Aciklama { get; set; }

        public ICollection<Urun> Urunler { get; set; }
    }
}
