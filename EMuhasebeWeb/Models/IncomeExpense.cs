namespace EMuhasebeWeb.Models
{
    public class IncomeExpense
    {
        public int IncomeExpenseID { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public bool IsIncome { get; set; } // true = gelir, false = gider
    }
}
