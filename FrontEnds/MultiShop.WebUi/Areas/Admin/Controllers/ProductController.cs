using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUi.Services.CatalogServices.CategoryServices;
using MultiShop.WebUi.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetProductWithCategoryAsync();
            return View(values);

        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var values = await _categoryService.GetAllCategoryAsync();

            List<SelectListItem> categorias = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID
                                               }).ToList();

            ViewBag.categorias = categorias;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto dto)
        {
            await _productService.CreateProductAsync(dto);
            return RedirectToAction("ProductList");
        }

        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {

            var values = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categories = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID
                                               }).ToList();

            ViewBag.categorias = categories;
            var response = await _productService.GetByIdProductAsync(id);
            return View(response);

        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto dto)
        {

            await _productService.UpdateProductAsync(dto);
            return RedirectToAction("ProductList");

        }
    }
}
