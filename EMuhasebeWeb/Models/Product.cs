namespace EMuhasebeWeb.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
