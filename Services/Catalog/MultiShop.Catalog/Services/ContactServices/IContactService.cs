using MultiShop.Catalog.Dtos.ContactDtos;

namespace MultiShop.Catalog.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactListAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task DeleteContactAsync(string id);
    }
}
