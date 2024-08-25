using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUi.Services.BasketServices;
using MultiShop.WebUi.Services.CatalogServices.ProductServices;
using MultiShop.WebUi.Services.DiscountServices;

namespace MultiShop.WebUi.Controllers
{
    public class BasketController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public BasketController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }
        public async Task<IActionResult> ShoppingCart()
        {
            var values = await _basketService.GetBasketList();
            ViewBag.ShoppingCart = values.TotalPrice;
            return View();

        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductID = values.ProductID,
                ProductName = values.ProductName,
                Price = values.Price,
                Quantity = 1,
                ProductImageUrl = values.ProductImageUrl
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("ShoppingCart");
        }

        public  async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("ShoppingCart");
        }
    }
}
