using System.ComponentModel.DataAnnotations;

namespace EMuhasebeWeb.Models
{
    public class IncomeExpense
    {
        public int IncomeExpenseID { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public bool IsIncome { get; set; } // true: income, false: expense

        public string? Description { get; set; }
    }
}
