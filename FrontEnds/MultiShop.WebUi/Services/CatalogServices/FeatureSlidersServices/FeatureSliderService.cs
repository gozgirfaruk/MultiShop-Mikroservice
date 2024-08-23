using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.CatalogServices.FeatureSlidersServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSlider)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("FeatureSliders", createFeatureSlider);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _httpClient.DeleteAsync($"FeatureSliders?id={id}");
        }

        public Task FeatureSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<GetFeatureSliderDto>> GetFeatureSliderAsync()
        {
            var response = await _httpClient.GetAsync("featuresliders");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetFeatureSliderDto>>(jsonData);
            return values;
        }

        public async Task<UpdateFeatureSliderDto> GetFeatureSliderByIdAsync(string id)
        {
            var responseMesssage = await _httpClient.GetAsync($"featuresliders/{id}");
            var values = await responseMesssage.Content.ReadFromJsonAsync<UpdateFeatureSliderDto>();
            return values;
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSlider)
        {
            await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("featuresliders", updateFeatureSlider);
        }
    }
}
