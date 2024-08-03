using MultiShop.Catalog.Dtos.FeatureDtos;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetFeatureListAsync();
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeatureAsync(string id);
        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task<GetFeaureByIdDto> GetFeaureByIdAsync(string id);
    }
}
