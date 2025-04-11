using System.ComponentModel.DataAnnotations;

namespace EMuhasebeWeb.Models
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }

        [Required]
        public string AdSoyad { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Sifre { get; set; }

        public int RolID { get; set; }
        public Rol Rol { get; set; }

        public ICollection<Fatura> Faturalar { get; set; }
    }
}
