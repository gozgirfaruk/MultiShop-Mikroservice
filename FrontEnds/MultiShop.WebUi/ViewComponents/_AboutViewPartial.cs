using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.WebUi.Services.CatalogServices.AboutServices;
using MultiShop.WebUi.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;

namespace MultiShop.WebUi.ViewComponents
{
    public class _AboutViewPartial : ViewComponent
    {
       private readonly IAboutService _aboutService;

        public _AboutViewPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           var values = await _aboutService.GetAboutListAsync();
            return View(values);
        }
    }
}
