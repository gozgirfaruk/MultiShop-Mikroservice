
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.StatisticServices.UserStatisticServices
{
    public class UserStatisticService : IUserStatisticService
    {
        private readonly HttpClient _httpClient;

        public UserStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetUserCount()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5001/api/users/GetUserList");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            return jsonData.Count();
        }
    }
}
