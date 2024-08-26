using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
