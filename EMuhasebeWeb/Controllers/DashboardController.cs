using EMuhasebeWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMuhasebeWeb.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new DashboardViewModel
            {
                UserCount = _context.Users.Count(),
                CustomerCount = _context.Customers.Count(),
                InvoiceCount = _context.Invoices.Count(),
                TodayIncome = _context.IncomeExpenses
                    .Where(i => i.IsIncome && i.Date.Date == DateTime.Today)
                    .Sum(i => (decimal?)i.Amount) ?? 0,
                TodayExpense = _context.IncomeExpenses
                    .Where(i => !i.IsIncome && i.Date.Date == DateTime.Today)
                    .Sum(i => (decimal?)i.Amount) ?? 0
            };

            return View(model);
        }
    }
}
