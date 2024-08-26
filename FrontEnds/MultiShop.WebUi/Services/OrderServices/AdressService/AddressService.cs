using MultiShop.DtoLayer.OrderDtos.AdressesDtos;

namespace MultiShop.WebUi.Services.OrderServices.AdressService
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOrderAddressAsync(CreateAddressDto createAddressDto)
        {
            await _httpClient.PostAsJsonAsync<CreateAddressDto>("addresses", createAddressDto);
        }
    }
}
