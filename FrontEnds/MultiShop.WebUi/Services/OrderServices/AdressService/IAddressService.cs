using MultiShop.DtoLayer.OrderDtos.AdressesDtos;

namespace MultiShop.WebUi.Services.OrderServices.AdressService
{
    public interface IAddressService
    {
        Task CreateOrderAddressAsync(CreateAddressDto createAddressDto);

    }
}
