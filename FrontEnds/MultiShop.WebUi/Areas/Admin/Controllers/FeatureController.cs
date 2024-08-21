using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUi.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Feature/[action]")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IActionResult> FeatureList()
        {
           var values = await _featureService.GetFeatureListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeature)
        {

           await _featureService.CreateFeatureAsync(createFeature);
            return RedirectToAction("FeatureList");
        }
        [Route("{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
           await _featureService.DeleteFeatureAsync(id);
            return RedirectToAction("FeatureList");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            var values = await _featureService.GetFeaureByIdAsync(id);
            return View(values);
        }
        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto dto)
        {
           await _featureService.UpdateFeatureAsync(dto);
            return RedirectToAction("FeatureList");
        }
    }
}
