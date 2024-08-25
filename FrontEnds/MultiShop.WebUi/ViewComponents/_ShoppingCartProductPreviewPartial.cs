using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.BasketServices;

namespace MultiShop.WebUi.ViewComponents
{
    public class _ShoppingCartProductPreviewPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _ShoppingCartProductPreviewPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basketTotal = await _basketService.GetBasketList();
            var basketItem = basketTotal.BasketItems;
            return View(basketItem);
        }
    }
}
