using MultiShop.DtoLayer.OrderingDtos;

namespace MultiShop.WebUi.Services.OrderServices.OrderingServices
{
    public class OrderingService : IOrderingService
    {
        private readonly HttpClient _httpClient;

        public OrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserIdAysnc(string id)
        {
            var values = await _httpClient.GetAsync($"ordering/GetByUserId?id={id}");
            var result = await values.Content.ReadFromJsonAsync<List<ResultOrderingByUserIdDto>>();
            return result;
        }
    }
}
