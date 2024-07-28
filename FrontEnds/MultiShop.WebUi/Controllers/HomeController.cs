using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
