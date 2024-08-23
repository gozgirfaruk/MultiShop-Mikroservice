using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUi.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUi.ViewComponents
{
    public class _ShopProductWithCategoryViewPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _ShopProductWithCategoryViewPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productService.GetProductWithCategoryByIdAsync(id);
            return View(values);
        }
    }
}
