using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.WebUi.Services.CatalogServices.FeatureSlidersServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/[controller]/[action]")]
    public class FeatureSliderController : Controller
    {

        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _featureSliderService.GetFeatureSliderAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateFeatureSlider()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto dto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            var values = await _featureSliderService.GetFeatureSliderByIdAsync(id);
            return View(values);
        }


        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto dto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(dto);
            return RedirectToAction("Index");
        }

        [Route("{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return RedirectToAction("Index");
        }
    }
}
