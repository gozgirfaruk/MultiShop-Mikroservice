using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync($"productimages?id={id}");
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var value = await _httpClient.GetAsync("productimages");
            var jsonData  = await value.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultProductImageDto>>(jsonData);
            return result;
        }

        public async Task<GetByIdProductImageDto> GetProductImageForProductById(string id)
        {
            var value = await _httpClient.GetAsync($"productimages/GetProductImageForProductById?id={id}");
            var result = await value.Content.ReadFromJsonAsync<GetByIdProductImageDto>();
            return result;
        }

        public Task UpdateProductImageAsync(UpdateProductImageDto productImageDto)
        {
            throw new NotImplementedException();
        }
    }
}
