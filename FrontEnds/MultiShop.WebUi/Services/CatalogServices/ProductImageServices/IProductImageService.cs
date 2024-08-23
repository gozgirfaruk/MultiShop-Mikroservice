using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUi.Services.CatalogServices.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task UpdateProductImageAsync(UpdateProductImageDto productImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetProductImageForProductById(string id);
    }
}
