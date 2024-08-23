using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.CatalogServices.CarouselServices
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
            var responseMessage = await _httpClient.GetAsync("FeatureSliders");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetFeatureSliderDto>>(jsonData);
            return values;
        }

        public async Task<List<ResultSpecialOfferDto>> GetSpecialOfferListAsync()
        {
            var responseMessage = await _httpClient.GetAsync("SpecialOffers");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
            return values;
        }


    }
}
