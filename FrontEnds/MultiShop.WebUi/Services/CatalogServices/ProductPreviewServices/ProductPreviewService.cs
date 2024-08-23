using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.CatalogServices.ProductPreviewServices
{
    public class ProductPreviewService : IProductPreviewService
    {
        private readonly HttpClient _httpClient;

        public ProductPreviewService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto productDetailDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDetailDto>("productpreviews", productDetailDto);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync($"productpreviews?id={id}");
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var responseMessage = await _httpClient.GetAsync("productpreviews");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDetailDto>>(jsonData);
            return values;
        }

        public async Task<GetProductDetailByIdDto> GetByIdProductDetailAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"productpreviews/getProductpreviewByid/{id}");
            var values = await responseMessage.Content.ReadFromJsonAsync<GetProductDetailByIdDto>();
            return values;
        }

        public async Task<GetProductDetailByIdDto> GetProductDetailForProductIdAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"productpreviews/getproductdetailforproductid?id={id}");
            var values = await responseMessage.Content.ReadFromJsonAsync<GetProductDetailByIdDto>();
            return values;
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto productDetailDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDetailDto>("productpreviews", productDetailDto);
        }
    }
}
