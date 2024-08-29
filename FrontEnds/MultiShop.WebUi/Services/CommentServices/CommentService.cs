using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            await _httpClient.PostAsJsonAsync("comments", createCommentDto);
        }

        public async Task DeleteCommentAsync(int id)
        {
            await _httpClient.DeleteAsync($"comments?id={id}");
        }

        public async Task<int> GetActiveCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("comments/GetActiveCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            var values = await _httpClient.GetAsync("comments");
            var jsonData = await values.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            return result;
        }

        public async Task<GetCommentById> GetCommentByIdAsync(int id)
        {
            var values = await _httpClient.GetAsync($"comments/{id}");
            var result = await values.Content.ReadFromJsonAsync<GetCommentById>();
            return result;
        }

        public async Task<List<GetCommentById>> GetCommentForProductId(string id)
        {
            var values = await _httpClient.GetAsync($"comments/GetCommentForProductId?id={id}");
            var jsonData = await values.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<GetCommentById>>(jsonData);
            return result;
        }

        public async Task<int> GetPassiveCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("comments/GetPassiveCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<int> GetTotalCommentCount()
        {
            var responseMessage = await _httpClient.GetAsync("comments/GetCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            await _httpClient.PutAsJsonAsync("comments", updateCommentDto);

        }
    }
}
