using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Areas.User.Controllers
{
    [Area("User")]
    public class MyCargoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
