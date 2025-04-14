namespace EMuhasebeWeb.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
