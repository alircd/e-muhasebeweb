namespace EMuhasebeWeb.Models
{
    public class Company
    {
        public int CompanyID { get; set; } // ✅ Primary Key

        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public string Address { get; set; }
        public string LogoPath { get; set; }
    }
}
