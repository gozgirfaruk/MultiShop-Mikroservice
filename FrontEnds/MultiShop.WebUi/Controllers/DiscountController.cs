using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.BasketServices;
using MultiShop.WebUi.Services.DiscountServices;

namespace MultiShop.WebUi.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;

        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public PartialViewResult ConfirmCoupon()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmCoupon(string code)
        {
            var values = await _discountService.GetDiscountCode(code);
            var basketValues = await _basketService.GetBasketList();
            if (values.Code == code)
            {

                var discountApply = basketValues.TotalPrice - (basketValues.TotalPrice / 100 * values.Rate);
                ViewBag.CouponCode = discountApply.ToString();
            }
            else
            {

                ViewBag.errorCode = "Geçersiz Kupon Kodu Lütfen Tekrar Deneyiniz.";
            }

            return RedirectToAction("ShoppingCart", "Discount", new { @code = code });

        }

    }
}
