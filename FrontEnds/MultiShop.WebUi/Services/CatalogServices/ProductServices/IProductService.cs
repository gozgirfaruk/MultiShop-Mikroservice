using MultiShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MultiShop.WebUi.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<UpdateProductDto> GetByIdProductAsync(string id);
        Task<GetProductByIdDto> GetProductWithGetDto(string id);
        Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryAsync();
        Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryByIdAsync(string CategoryId);

    }
}
