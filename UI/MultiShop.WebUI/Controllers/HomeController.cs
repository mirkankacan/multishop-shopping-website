using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Directory1 = "Home";
            ViewBag.Directory2 = "";
            return View();
        }
    }
}