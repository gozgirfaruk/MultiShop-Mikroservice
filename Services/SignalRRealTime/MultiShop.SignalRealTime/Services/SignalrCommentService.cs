
using Newtonsoft.Json;

namespace MultiShop.SignalRealTime.Services
{
    public class SignalrCommentService : ISignalrCommentService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalrCommentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<int> GetTotalCommentCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7061/api/Comments/GetCommentCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var commentCount = JsonConvert.DeserializeObject<int>(jsonData);
            return commentCount;
        }
    }
}
