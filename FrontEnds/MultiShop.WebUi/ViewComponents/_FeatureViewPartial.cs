using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUi.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;

namespace MultiShop.WebUi.ViewComponents
{
    public class _FeatureViewPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _FeatureViewPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureService.GetFeatureListAsync();
            return View(values);
        }
    }
}
