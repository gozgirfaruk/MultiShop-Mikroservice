using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.WebUi.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> AboutList()
        {
            var values = await _aboutService.GetAboutListAsync();
            return View(values);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            var values = await _aboutService.GetAboutByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
          await _aboutService.UpdateAboutAsync(updateAboutDto);
            return RedirectToAction("AboutList");
        }
    }
}
