using MultiShop.Catalog.Dtos.FeatureSliderDtos;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetFeatureSliderAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSlider);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSlider);
        Task DeleteFeatureSliderAsync(string id);
        Task<GetFeatureSliderByIdDto> GetFeatureSliderByIdAsync(string id);
        Task FeatureSliderChangeStatusToTrue(string id);
        Task FeatureSliderChangeStatusToFalse(string id);   
    }
}
