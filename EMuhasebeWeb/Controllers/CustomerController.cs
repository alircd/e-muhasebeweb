using EMuhasebeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMuhasebeWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Form bilgileri geçersiz.";
                return View(customer);
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();
            TempData["Success"] = "Müşteri başarıyla eklendi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                TempData["Error"] = "Düzenlenecek müşteri bulunamadı.";
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Form bilgileri geçersiz.";
                return View(customer);
            }

            _context.Customers.Update(customer);
            _context.SaveChanges();
            TempData["Success"] = "Müşteri bilgisi güncellendi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.CustomerID == id);
            if (customer == null)
            {
                TempData["Error"] = "Silinecek müşteri bulunamadı.";
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                TempData["Success"] = "Müşteri silindi.";
            }
            else
            {
                TempData["Error"] = "Müşteri bulunamadı.";
            }

            return RedirectToAction("Index");
        }
    }
}
