using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MultiShop.WebUi.Services.CatalogServices.ProductPreviewServices
{
    public interface IProductPreviewService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto productDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto productDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetProductDetailByIdDto> GetByIdProductDetailAsync(string id);
        Task<GetProductDetailByIdDto> GetProductDetailForProductIdAsync(string id);
    }
}
