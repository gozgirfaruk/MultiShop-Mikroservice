
namespace MultiShop.WebUi.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long> GetBrandCount()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetBrandCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }

        public async Task<long> GetCategoryCount()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetCategoryCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }

        public Task<decimal> GetProductAvgPrice()
        {
            throw new NotImplementedException();
        }

        public async Task<long> GetProductCount()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetProductCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }

        public async Task<string> GetProductMaxPrice()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetProductMaxPrice");
            var values = await responseMessage.Content.ReadAsStringAsync();
            return values;
        }

        public async Task<string> GetProductMinPrice()
        {
            var responseMessage = await _httpClient.GetAsync("statistics/GetProductMinPrice");
            var values = await responseMessage.Content.ReadAsStringAsync();
            return values;
        }
    }
}
