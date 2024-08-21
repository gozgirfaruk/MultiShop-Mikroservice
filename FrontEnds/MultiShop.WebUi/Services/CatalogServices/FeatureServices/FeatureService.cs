using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.CatalogServices.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _htttpClient;
        public FeatureService(HttpClient htttpClient)
        {
            _htttpClient = htttpClient;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            await _htttpClient.PostAsJsonAsync<CreateFeatureDto>("features", createFeatureDto);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _htttpClient.DeleteAsync($"features?id={id}");
        }

        public async Task<List<ResultFeatureDto>> GetFeatureListAsync()
        {
            var responseMessage = await _htttpClient.GetAsync("features");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
            return values;
        }

        public async Task<UpdateFeatureDto> GetFeaureByIdAsync(string id)
        {
            var response = await _htttpClient.GetAsync($"features?id={id}");
            var valeus =await response.Content.ReadFromJsonAsync<UpdateFeatureDto>();
            return valeus;
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            await _htttpClient.PutAsJsonAsync<UpdateFeatureDto>("features", updateFeatureDto);
        }
    }
}
