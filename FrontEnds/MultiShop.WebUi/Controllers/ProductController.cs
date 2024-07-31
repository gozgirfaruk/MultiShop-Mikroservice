using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Shop()
        {
            return View();
        }

        public IActionResult ProductDetail()
        {
            return View();
        }
    }
}
