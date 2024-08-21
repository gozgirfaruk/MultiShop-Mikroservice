using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUi.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;
using NuGet.Versioning;
using System.Text;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OfferDiscount/[action]")]
    public class OfferDiscountController : Controller
    {
     
        private readonly IOfferDiscountService _offerDiscountService;

        public OfferDiscountController(IOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        public async Task<IActionResult> OfferDiscountList()
        {

            var values = await _offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }
        [Route("{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
           await _offerDiscountService.DeleteOfferDiscountAsync(id);
            return RedirectToAction("OfferDiscountList");
        }
        [HttpGet]
        public IActionResult CreateOfferDiscount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto dto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(dto); return RedirectToAction("OfferDiscountList");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
           var values = await _offerDiscountService.GetOfferDiscountByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto dto)
        {
           await _offerDiscountService.UpdateOfferDiscountAsync(dto); return RedirectToAction("OfferDiscountList");

        }
    }
}
