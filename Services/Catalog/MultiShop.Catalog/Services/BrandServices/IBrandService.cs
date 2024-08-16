using MultiShop.Catalog.Dtos.BrandDtos;

namespace MultiShop.Catalog.Services.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task CreateBrandAsync(CreateBrandDto createBrand);
        Task UpdateBrandAsync(UpdateBrandDto updateBrand);
        Task DeleteBrandAsync(string id);
        Task<GetBrandByIdDto> GetBrandById(string id);
    }
}
