using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.WebUi.Services.CatalogServices.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDto createOfferDto);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateOfferDto);
        Task DeleteCategoryAsync(string id);
        Task<UpdateSpecialOfferDto> GetSpecialOfferByIdAsync(string id);
    }
}
