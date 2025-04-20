using EMuhasebeWeb.Helpers;
using EMuhasebeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EMuhasebeWeb.Controllers
{
    public class ReportController : Controller
    {
        private readonly AppDbContext _context;
        private readonly PdfGenerator _pdfGenerator;

        public ReportController(AppDbContext context, PdfGenerator pdfGenerator)
        {
            _context = context;
            _pdfGenerator = pdfGenerator;
        }

        public IActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            var list = _context.IncomeExpenses.AsQueryable();

            if (startDate.HasValue)
                list = list.Where(i => i.Date >= startDate.Value);

            if (endDate.HasValue)
                list = list.Where(i => i.Date <= endDate.Value);

            var income = list.Where(i => i.IsIncome).Sum(i => (decimal?)i.Amount) ?? 0;
            var expense = list.Where(i => !i.IsIncome).Sum(i => (decimal?)i.Amount) ?? 0;

            ViewBag.TotalIncome = income;
            ViewBag.TotalExpense = expense;
            ViewBag.StartDate = startDate?.ToString("yyyy-MM-dd");
            ViewBag.EndDate = endDate?.ToString("yyyy-MM-dd");

            return View(list.ToList());
        }

        [HttpPost]
        public IActionResult ExportToPdf(DateTime? startDate, DateTime? endDate)
        {
            var list = _context.IncomeExpenses.AsQueryable();

            if (startDate.HasValue)
                list = list.Where(i => i.Date >= startDate.Value);

            if (endDate.HasValue)
                list = list.Where(i => i.Date <= endDate.Value);

            var data = list.ToList();

            StringBuilder html = new StringBuilder();
            html.Append("<h2>Income & Expense Report</h2>");
            html.Append("<table border='1' cellpadding='5' cellspacing='0'><thead><tr>");
            html.Append("<th>Date</th><th>Description</th><th>Amount</th><th>Type</th></tr></thead><tbody>");

            foreach (var item in data)
            {
                html.Append("<tr>");
                html.Append($"<td>{item.Date:yyyy-MM-dd}</td>");
                html.Append($"<td>{item.Description}</td>");
                html.Append($"<td>{item.Amount} ₺</td>");
                html.Append($"<td>{(item.IsIncome ? "Income" : "Expense")}</td>");
                html.Append("</tr>");
            }

            html.Append("</tbody></table>");

            var pdfBytes = _pdfGenerator.GeneratePdfFromHtml(html.ToString());
            return File(pdfBytes, "application/pdf", "IncomeExpenseReport.pdf");
        }
    }
}
