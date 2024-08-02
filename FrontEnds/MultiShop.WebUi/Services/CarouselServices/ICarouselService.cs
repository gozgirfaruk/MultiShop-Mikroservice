using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUi.Services.CarouselServices
{
    public interface ICarouselService
    {
        Task<List<GetFeatureSliderDto>> GetCarouselAsync();
    }
}
