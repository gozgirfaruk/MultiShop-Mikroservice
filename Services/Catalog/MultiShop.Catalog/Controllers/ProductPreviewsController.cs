using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductPreviewDtos;
using MultiShop.Catalog.Services.ProductPreviewServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPreviewsController : ControllerBase
    {
        private readonly IProductPreviewService _productPreviewService;

        public ProductPreviewsController(IProductPreviewService productPreviewService)
        {
            _productPreviewService = productPreviewService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductPreviewList()
        {
            var values = await _productPreviewService.GetAllProductPreviewAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductPreview(CreateProductPreviewDto createProductPreviewDto)
        {
            await _productPreviewService.CreateProductPreviewAsync(createProductPreviewDto);
            return Ok();
        }
        [HttpGet("GetProductPreviewById")]
        public async Task<IActionResult> GetProductPreviewById(string id)
        {
            var values = await _productPreviewService.GetByIdProductPreviewAsync(id);
            return Ok(values);
        }
        [HttpGet("GetProductDetailForProductId")]
        public async Task<IActionResult> GetProductDetailForProductId(string id)
        {
            var values = await _productPreviewService.GetProductDetailForProductIdAsync(id);
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductPreview(UpdateProductPreviewDto updateProductPreviewDto)
        {
            await _productPreviewService.UpdateProductPreviewAsync(updateProductPreviewDto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductPreview(string id)
        {
            await _productPreviewService.DeleteProductPreviewAsync(id);
            return Ok();
        }
    }
}
