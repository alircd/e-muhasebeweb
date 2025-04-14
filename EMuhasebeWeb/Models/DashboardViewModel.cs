namespace EMuhasebeWeb.Models
{
    public class DashboardViewModel
    {
        public int CustomerCount { get; set; }
        public int ProductCount { get; set; }
        public int InvoiceCount { get; set; }
        public decimal TodayIncome { get; set; }
        public decimal TodayExpense { get; set; }
        public int UserCount { get; internal set; }
    }

}
