namespace EMuhasebeWeb.Models
{
    public class Rol
    {
        public int RolID { get; set; }
        public string Ad { get; set; }

        public ICollection<Kullanici> Kullanicilar { get; set; }
    }
}
