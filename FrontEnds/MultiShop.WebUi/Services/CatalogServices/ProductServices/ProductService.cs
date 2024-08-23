using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto productDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDto>("products", productDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync($"products?id={id}");
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return values;
        }

        public async Task<UpdateProductDto> GetByIdProductAsync(string id)
        {
            //669687ecba5c665a2dc59e42

            var values = await _httpClient.GetAsync($"products/{id}");
            var respon = await values.Content.ReadFromJsonAsync<UpdateProductDto>();
            return respon;
        }



        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("products/productlistwithcategory");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryByIdAsync(string CategoryId)
        {
            var responseMessage = await _httpClient.GetAsync($"products/productlistwithcategorybyid?id={CategoryId}");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultProductWithCategoryDto>>();
            return values;
        }

        public async Task<GetProductByIdDto> GetProductWithGetDto(string id)
        {
            var values = await _httpClient.GetAsync($"products/getproductbyid?id={id}");
            var respon = await values.Content.ReadFromJsonAsync<GetProductByIdDto>();
            return respon;
        }

        public Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
