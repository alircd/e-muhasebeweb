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
            return View(_context.IncomeExpenses.ToList());
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(IncomeExpense model)
        {
            if (ModelState.IsValid)
            {
                _context.IncomeExpenses.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var item = _context.IncomeExpenses.Find(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(IncomeExpense model)
        {
            if (ModelState.IsValid)
            {
                _context.IncomeExpenses.Update(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var item = _context.IncomeExpenses.Find(id);
            if (item != null)
            {
                _context.IncomeExpenses.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}