using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createOfferDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateSpecialOfferDto>("specialoffers", createOfferDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync($"specialoffers?id={id}");
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var responseMessage = await _httpClient.GetAsync("specialoffers");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
            return values;
        }

        public async Task<UpdateSpecialOfferDto> GetSpecialOfferByIdAsync(string id)
        {
            var values = await _httpClient.GetAsync($"specialoffers/{id}");
            var respon = await values.Content.ReadFromJsonAsync<UpdateSpecialOfferDto>();
            return respon;
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateOfferDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateSpecialOfferDto>("specialoffers", updateOfferDto);
        }
    }
}
