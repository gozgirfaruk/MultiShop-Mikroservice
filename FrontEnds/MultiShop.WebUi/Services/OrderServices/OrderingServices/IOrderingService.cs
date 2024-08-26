using MultiShop.DtoLayer.OrderingDtos;

namespace MultiShop.WebUi.Services.OrderServices.OrderingServices
{
    public interface IOrderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserIdAysnc(string id);
    }
}
