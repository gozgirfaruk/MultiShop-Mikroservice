using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.CarouselServices
{
    public class CarouselService : ICarouselService
    {
        private readonly HttpClient _httpClient;

        public CarouselService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GetFeatureSliderDto>> GetCarouselAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7186/api/FeatureSliders");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetFeatureSliderDto>>(jsonData);
                return values;
            }
            return null;
        }

        public async Task<List<ResultSpecialOfferDto>> GetSpecialOfferListAsync()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7186/api/SpecialOffers");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
                return values.ToList();
            }
            return null;
        }
    }
}
