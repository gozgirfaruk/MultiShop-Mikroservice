using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUi.Services.CatalogServices.ProductImageServices;
using Newtonsoft.Json;

namespace MultiShop.WebUi.ViewComponents
{
    public class _ProductDetailImageViewPartial : ViewComponent
    {

        private readonly IProductImageService _productImageService;

        public _ProductDetailImageViewPartial(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var value = await _productImageService.GetProductImageForProductById(id);
            return View(value);
     
        }
    }
}
