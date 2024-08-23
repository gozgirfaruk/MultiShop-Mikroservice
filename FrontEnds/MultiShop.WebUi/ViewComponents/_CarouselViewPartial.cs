using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.CatalogServices.CarouselServices;
using MultiShop.WebUi.Services.CatalogServices.FeatureSlidersServices;

namespace MultiShop.WebUi.ViewComponents
{
    public class _CarouselViewPartial : ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;

        public _CarouselViewPartial(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureSliderService.GetFeatureSliderAsync();
            return View(values);
        }
    }
}
