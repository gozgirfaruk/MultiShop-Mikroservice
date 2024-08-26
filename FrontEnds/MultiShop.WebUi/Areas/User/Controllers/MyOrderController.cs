using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.Interfaces;
using MultiShop.WebUi.Services.OrderServices.OrderingServices;

namespace MultiShop.WebUi.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IOrderingService _orderingService;
        private readonly IUserService _userService;
        public MyOrderController(IOrderingService orderingService, IUserService userService)
        {
            _orderingService = orderingService;
            _userService = userService;
        }

        public async Task<IActionResult> MyOrderList()
        {
            var values = await _userService.GetUserInfo();
            var result = await _orderingService.GetOrderingByUserIdAysnc(values.Id);
            return View(result);
        }
    }
}
