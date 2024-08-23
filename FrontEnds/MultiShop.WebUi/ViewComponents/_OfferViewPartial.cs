using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUi.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;

namespace MultiShop.WebUi.ViewComponents
{
    public class _OfferViewPartial : ViewComponent
    {
        private readonly IOfferDiscountService _offerDiscountService;

        public _OfferViewPartial(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
          var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }
    }
}
