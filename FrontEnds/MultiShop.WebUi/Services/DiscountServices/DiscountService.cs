using MultiShop.DtoLayer.DiscountDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetCouponCount()
        {
            var values = await _httpClient.GetAsync("coupons/GetCouponCount");
            var result = await values.Content.ReadFromJsonAsync<int>();
            return result;  
        }

        public async Task<GetDiscountCodeDetail> GetDiscountCode(string code)
        {
            var responseMessage = await _httpClient.GetAsync($"coupons/GetCodeDetail?code={code}");
            var values =await responseMessage.Content.ReadFromJsonAsync<GetDiscountCodeDetail>();
            return values;
        }
    }
}
