namespace EMuhasebeWeb.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public DateTime Date { get; set; }
        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        public decimal TotalAmount { get; set; }

        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
