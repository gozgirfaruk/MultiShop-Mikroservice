using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUi.Services.CatalogServices.FeatureSlidersServices
{
    public interface IFeatureSliderService
    {
        Task<List<GetFeatureSliderDto>> GetFeatureSliderAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSlider);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSlider);
        Task DeleteFeatureSliderAsync(string id);
        Task<UpdateFeatureSliderDto> GetFeatureSliderByIdAsync(string id);
        Task FeatureSliderChangeStatusToTrue(string id);
        Task FeatureSliderChangeStatusToFalse(string id);
    }
}
