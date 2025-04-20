using DinkToPdf.Contracts;
using EMuhasebeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EMuhasebeWeb.Helpers;

namespace EMuhasebeWeb.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IViewRenderService _viewRenderService;
        private readonly PdfGenerator _pdfGenerator;

        public InvoiceController(AppDbContext context, PdfGenerator pdfGenerator, IViewRenderService viewRenderService)
        {
            _context = context;
            _pdfGenerator = pdfGenerator;
            _viewRenderService = viewRenderService;
        }

        public IActionResult Index()
        {
            var invoices = _context.Invoices.Include(i => i.Customer).ToList();
            return View(invoices);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Customers = _context.Customers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Invoices.Add(invoice);
                _context.SaveChanges();
                TempData["success"] = "Invoice created successfully.";
                return RedirectToAction("Index");
            }

            ViewBag.Customers = _context.Customers.ToList();
            return View(invoice);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var invoice = _context.Invoices.Find(id);
            if (invoice == null)
                return NotFound();

            ViewBag.Customers = _context.Customers.ToList();
            return View(invoice);
        }

        [HttpPost]
        public IActionResult Edit(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                _context.Invoices.Update(invoice);
                _context.SaveChanges();
                TempData["success"] = "Invoice updated.";
                return RedirectToAction("Index");
            }

            ViewBag.Customers = _context.Customers.ToList();
            return View(invoice);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var invoice = _context.Invoices
                .Include(i => i.Customer)
                .FirstOrDefault(i => i.InvoiceID == id);
            return View(invoice);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var invoice = _context.Invoices.Find(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ExportToPdf(int id)
        {
            var invoice = _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.InvoiceDetails)
                .ThenInclude(d => d.Product)
                .FirstOrDefault(i => i.InvoiceID == id);

            if (invoice == null)
                return NotFound();

            var html = await _viewRenderService.RenderToStringAsync("Invoice/PdfTemplate", invoice);
            var pdfBytes = _pdfGenerator.GeneratePdfFromHtml(html);

            return File(pdfBytes, "application/pdf", $"invoice_{id}.pdf");
        }
    }
}
