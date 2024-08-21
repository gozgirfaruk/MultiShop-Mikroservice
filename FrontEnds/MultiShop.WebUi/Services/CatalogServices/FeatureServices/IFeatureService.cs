using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace MultiShop.WebUi.Services.CatalogServices.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetFeatureListAsync();
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeatureAsync(string id);
        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task<UpdateFeatureDto> GetFeaureByIdAsync(string id);
    }
}
