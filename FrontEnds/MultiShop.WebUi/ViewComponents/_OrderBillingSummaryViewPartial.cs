using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.BasketServices;

namespace MultiShop.WebUi.ViewComponents
{
    public class _OrderBillingSummaryViewPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _OrderBillingSummaryViewPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basketTotal = await _basketService.GetBasketList();
            var basketItems = basketTotal.BasketItems;
            return View(basketItems);
        }
    }
}
