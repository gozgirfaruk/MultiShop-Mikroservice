using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Shop(string id)
        {
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetail()
        {
            return View();
        }
    }
}
