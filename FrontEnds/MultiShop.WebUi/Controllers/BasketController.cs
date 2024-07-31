using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult ShoppingCart()
        {
            return View();
        }
    }
}
