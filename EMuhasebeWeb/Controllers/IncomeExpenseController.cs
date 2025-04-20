using EMuhasebeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMuhasebeWeb.Controllers
{
    public class IncomeExpenseController : Controller
    {
        private readonly AppDbContext _context;

        public IncomeExpenseController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.IncomeExpenses.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IncomeExpense model)
        {
            if (ModelState.IsValid)
            {
                _context.IncomeExpenses.Add(model);
                _context.SaveChanges();
                TempData["success"] = "Record saved successfully.";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var record = _context.IncomeExpenses.Find(id);
            if (record == null) return NotFound();
            return View(record);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(IncomeExpense model)
        {
            if (ModelState.IsValid)
            {
                _context.IncomeExpenses.Update(model);
                _context.SaveChanges();
                TempData["success"] = "Record updated successfully.";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var record = _context.IncomeExpenses.Find(id);
            if (record == null) return NotFound();
            return View(record);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var record = _context.IncomeExpenses.Find(id);
            if (record != null)
            {
                _context.IncomeExpenses.Remove(record);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
