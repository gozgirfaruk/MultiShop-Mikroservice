using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;

namespace MultiShop.WebUi.Services.CatalogServices.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
        Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscount);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscount);
        Task DeleteOfferDiscountAsync(string id);
        Task<UpdateOfferDiscountDto> GetOfferDiscountByIdAsync(string id);
    }
}
