using MultiShop.Catalog.Dtos.SpecialOffierDtos;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto createOfferDto);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateOfferDto);
        Task DeleteCategoryAsync(string id);
        Task<GetSpecialOfferByIdDto> GetSpecialOfferByIdAsync(string id);
    }
}
