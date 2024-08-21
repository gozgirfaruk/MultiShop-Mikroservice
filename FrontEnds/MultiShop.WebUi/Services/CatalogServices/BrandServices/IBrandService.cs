using MultiShop.DtoLayer.CatalogDtos.BrandDtos;

namespace MultiShop.WebUi.Services.CatalogServices.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task CreateBrandAsync(CreateBrandDto createBrand);
        Task UpdateBrandAsync(UpdateBrandDto updateBrand);
        Task DeleteBrandAsync(string id);
        Task<UpdateBrandDto> GetBrandById(string id);
    }
}
