using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUi.Controllers
{
    [AllowAnonymous]
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
