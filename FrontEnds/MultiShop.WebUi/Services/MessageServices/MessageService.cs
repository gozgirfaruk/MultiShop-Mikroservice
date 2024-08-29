using MultiShop.DtoLayer.MessageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultInboxDto>> GetAllInboxAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"usermessage/getinbox?id={id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultInboxDto>>(jsonData);
            return values;
        }

        public async Task<List<ResultSendboxDto>> GetAllSendboxAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"usermessage/getsendbox?id={id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSendboxDto>>(jsonData);
            return values;
        }

        public async Task<int> GetTotalMessageCount()
        {
            var value = await _httpClient.GetAsync("usermessage/GetTotalMessageCount");
            var result = await value.Content.ReadFromJsonAsync<int>();
            return result;
        }
    }
}
