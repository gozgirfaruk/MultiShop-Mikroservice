using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.WebUi.Services.CatalogServices.CarouselServices
{
    public interface ICarouselService
    {
        Task<List<GetFeatureSliderDto>> GetCarouselAsync();
        Task<List<ResultSpecialOfferDto>> GetSpecialOfferListAsync();
    }
}
