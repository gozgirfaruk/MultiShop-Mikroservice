using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.CarouselServices;

namespace MultiShop.WebUi.ViewComponents
{
    public class _SpecialOfferViewPartial : ViewComponent
    {
        private readonly ICarouselService _carouselService;

        public _SpecialOfferViewPartial(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _carouselService.GetSpecialOfferListAsync();
            return View(values);
        }
    }
}
