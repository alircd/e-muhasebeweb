using EMuhasebeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMuhasebeWeb.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly AppDbContext _context;

        public InvoiceController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Invoices.Include(i => i.Customer).ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Customers = _context.Customers.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Invoice model)
        {
            if (ModelState.IsValid)
            {
                _context.Invoices.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customers = _context.Customers.ToList();
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var item = _context.Invoices.Find(id);
            if (item != null)
            {
                _context.Invoices.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}