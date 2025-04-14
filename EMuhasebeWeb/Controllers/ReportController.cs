using EMuhasebeWeb.Helpers;
using EMuhasebeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EMuhasebeWeb.Controllers
{
    public class ReportController : Controller
    {
        private readonly AppDbContext _context;

        public ReportController(AppDbContext context)
        {
            _context = context;
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
            html.Append("<h2>Gelir-Gider Raporu</h2>");
            html.Append("<table border='1' cellpadding='5'><tr><th>Tarih</th><th>Açıklama</th><th>Tutar</th><th>Tür</th></tr>");

            foreach (var item in data)
            {
                html.Append($"<tr><td>{item.Date:yyyy-MM-dd}</td><td>{item.Description}</td><td>{item.Amount} ₺</td><td>{(item.IsIncome ? "Gelir" : "Gider")}</td></tr>");
            }

            html.Append("</table>");

            var pdfBytes = PdfGenerator.GeneratePdfFromHtml(html.ToString());
            return File(pdfBytes, "application/pdf", "GelirGiderRaporu.pdf");
        }
    }
}
