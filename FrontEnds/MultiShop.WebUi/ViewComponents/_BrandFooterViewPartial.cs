using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUi.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;

namespace MultiShop.WebUi.ViewComponents
{
    public class _BrandFooterViewPartial : ViewComponent
    {
        private readonly IBrandService _brandService;

        public _BrandFooterViewPartial(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _brandService.GetAllBrandAsync();
            return View(values);
        }
    }
}
