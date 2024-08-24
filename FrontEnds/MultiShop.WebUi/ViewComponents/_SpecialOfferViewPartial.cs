using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.CatalogServices.CarouselServices;
using MultiShop.WebUi.Services.CatalogServices.SpecialOfferServices;

namespace MultiShop.WebUi.ViewComponents
{
    public class _SpecialOfferViewPartial : ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;

        public _SpecialOfferViewPartial(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

      

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }
    }
}
