
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.SignalRealTime.Services.CommentServices
{
    public class SignalrService : ISignalrCommentService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalrService(IHttpClientFactory httpClientFactory)
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
