using MultiShop.Catalog.Dtos.OfferDiscountDtos;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
        Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscount);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscount);
        Task DeleteOfferDiscountAsync(string id);
        Task<GetOfferDiscountById> GetOfferDiscountByIdAsync(string id);
    }
}
