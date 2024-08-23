using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUi.Services.CatalogServices.ProductPreviewServices;
using Newtonsoft.Json;

namespace MultiShop.WebUi.ViewComponents
{
    public class _ProductDetailDescriptionViewPartial : ViewComponent
    {
      private readonly IProductPreviewService _productPreviewService;

        public _ProductDetailDescriptionViewPartial(IProductPreviewService productPreviewService)
        {
            _productPreviewService = productPreviewService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productPreviewService.GetProductDetailForProductIdAsync(id);
            return View(values);
          
        }
    }
}
