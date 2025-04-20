using EMuhasebeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMuhasebeWeb.Controllers
{
    public class InvoiceDetailController : Controller
    {
        private readonly AppDbContext _context;

        public InvoiceDetailController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Create(int invoiceId)
        {
            ViewBag.InvoiceID = invoiceId;
            ViewBag.Products = _context.Products.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InvoiceDetail detail)
        {
            if (ModelState.IsValid)
            {
                _context.InvoiceDetails.Add(detail);
                _context.SaveChanges();
                return RedirectToAction("Details", "Invoice", new { id = detail.InvoiceID });
            }
            ViewBag.InvoiceID = detail.InvoiceID;
            ViewBag.Products = _context.Products.ToList();
            return View(detail);
        }

        public IActionResult Delete(int id)
        {
            var detail = _context.InvoiceDetails
                .Include(d => d.Product)
                .FirstOrDefault(d => d.InvoiceDetailID == id);
            if (detail == null) return NotFound();
            return View(detail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var detail = _context.InvoiceDetails.Find(id);
            if (detail != null)
            {
                _context.InvoiceDetails.Remove(detail);
                _context.SaveChanges();
            }
            return RedirectToAction("Details", "Invoice", new { id = detail?.InvoiceID });
        }
    }
}
