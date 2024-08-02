using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.CarouselServices;

namespace MultiShop.WebUi.ViewComponents
{
    public class _CarouselViewPartial : ViewComponent
    {
        private readonly ICarouselService _carouselService;

        public _CarouselViewPartial(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _carouselService.GetCarouselAsync();
            return View(values);
        }
    }
}
