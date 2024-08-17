using MultiShop.Catalog.Dtos.ProductPreviewDtos;

namespace MultiShop.Catalog.Services.ProductPreviewServices
{
    public interface IProductPreviewService
    {
        Task<List<ResultProductPreviewDto>> GetAllProductPreviewAsync();
        Task CreateProductPreviewAsync(CreateProductPreviewDto productPreviewDto);
        Task UpdateProductPreviewAsync(UpdateProductPreviewDto productPreviewDto);
        Task DeleteProductPreviewAsync(string id);
        Task<GetProductPreviewByIdDto> GetByIdProductPreviewAsync(string id);
        Task<GetProductPreviewByIdDto> GetProductDetailForProductIdAsync(string id);
    }
}
