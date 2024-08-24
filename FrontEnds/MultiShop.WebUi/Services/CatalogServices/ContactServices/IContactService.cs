using MultiShop.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShop.WebUi.Services.CatalogServices.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactListAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task DeleteContactAsync(string id);
    }
}
