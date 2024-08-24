using MultiShop.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShop.WebUi.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync("contacts", createContactDto);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _httpClient.DeleteAsync($"contacts?id={id}");
        }

        public async Task<List<ResultContactDto>> GetAllContactListAsync()
        {
            var values = await _httpClient.GetAsync("contacts");
            var result = await values.Content.ReadFromJsonAsync<List<ResultContactDto>>();
            return result;
        }
    }
}
