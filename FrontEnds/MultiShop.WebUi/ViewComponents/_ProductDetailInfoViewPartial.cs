using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUi.Services.CatalogServices.ProductPreviewServices;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUi.ViewComponents
{
    public class _ProductDetailInfoViewPartial : ViewComponent
    {

        private readonly IProductPreviewService _productPreviewsService;

        public _ProductDetailInfoViewPartial( IProductPreviewService productPreviewsService)
        {
            _productPreviewsService = productPreviewsService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productPreviewsService.GetProductDetailForProductIdAsync(id);
            return View(values);
  
        }
    }
}
