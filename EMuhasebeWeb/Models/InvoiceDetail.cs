namespace EMuhasebeWeb.Models
{
    public class InvoiceDetail
    {
        public int InvoiceDetailID { get; set; }
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }

        public Product Product { get; set; }
        public Invoice Invoice { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
