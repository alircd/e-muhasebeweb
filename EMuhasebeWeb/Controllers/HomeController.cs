using Microsoft.AspNetCore.Mvc;

namespace EMuhasebeWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => RedirectToAction("Login", "Auth");
    }
}