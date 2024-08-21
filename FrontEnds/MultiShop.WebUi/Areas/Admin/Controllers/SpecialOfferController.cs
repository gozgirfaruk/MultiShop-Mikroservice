using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUi.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }

        public IActionResult CreateSpecialOffer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto dto)
        {
            await  _specialOfferService.CreateSpecialOfferAsync(dto);
            return RedirectToAction("Index");
        }
        [Route("{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
          await _specialOfferService.DeleteCategoryAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
           var values = await _specialOfferService.GetSpecialOfferByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto dto)
        {
           await _specialOfferService.UpdateSpecialOfferAsync(dto);
            return RedirectToAction("Index");
        }
        
    }
}
