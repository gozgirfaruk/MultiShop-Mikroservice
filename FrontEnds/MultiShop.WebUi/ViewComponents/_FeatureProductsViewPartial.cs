using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUi.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace MultiShop.WebUi.ViewComponents
{
    public class _FeatureProductsViewPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _FeatureProductsViewPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }
    }
}
