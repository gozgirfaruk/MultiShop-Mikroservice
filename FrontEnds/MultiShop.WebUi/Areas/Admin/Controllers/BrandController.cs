using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUi.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IActionResult> BrandList()
        {
            var values = await _brandService.GetAllBrandAsync();
            return View(values);
        }
        [Route("{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
           await _brandService.DeleteBrandAsync(id);
            return RedirectToAction("BrandList");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            var values = await _brandService.GetBrandById(id);
            return View(values);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto dto)
        {
            await _brandService.UpdateBrandAsync(dto);
            return RedirectToAction("BrandList");
        }

        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto dto)
        {
           await _brandService.CreateBrandAsync(dto);
            return RedirectToAction("BrandList");
        }
    }
}
