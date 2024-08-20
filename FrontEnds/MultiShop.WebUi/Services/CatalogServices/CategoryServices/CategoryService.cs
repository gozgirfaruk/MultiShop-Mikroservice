using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUi.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto categoryDto)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync<CreateCategoryDto>("categories",categoryDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync($"categories?id={id}");
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
           var responseMessage =  await _httpClient.GetAsync("categories");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultCategoryDto>>();
            return values;

        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"categories/{id}");
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdCategoryDto>();
            return values;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto categoryDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("categories", categoryDto);
        }
    }
}
