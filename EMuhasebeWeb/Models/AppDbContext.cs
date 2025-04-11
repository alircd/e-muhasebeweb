using Microsoft.EntityFrameworkCore;

namespace EMuhasebeWeb.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Fatura> Faturalar { get; set; }
        public DbSet<FaturaDetay> FaturaDetaylari { get; set; }
        public DbSet<Odeme> Odemeler { get; set; }
        public DbSet<GelirGider> GelirGiderler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Firma> Firmalar { get; set; }
    }
}
