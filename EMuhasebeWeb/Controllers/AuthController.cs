using EMuhasebeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMuhasebeWeb.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("KullaniciID") != null)
                return RedirectToAction("Index", "Dashboard");

            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string sifre)
        {
            var user = _context.Users.Include(k => k.Role).FirstOrDefault(k => k.Email == email && k.Password == sifre);
            if (user != null)
            {
                HttpContext.Session.SetString("KullaniciID", user.UserID.ToString());
                HttpContext.Session.SetString("Rol", user.Role?.Name?.Trim());
                return RedirectToAction("Index", "Dashboard");
            }
            ViewBag.Hata = "Hatalı e-posta veya şifre!";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}