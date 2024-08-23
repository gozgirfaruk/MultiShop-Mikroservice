using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUi.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;

namespace MultiShop.WebUi.ViewComponents
{
    public class _CategoriesViewPartial : ViewComponent
    {
     
        private readonly ICategoryService _categoryService;

        public _CategoriesViewPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
