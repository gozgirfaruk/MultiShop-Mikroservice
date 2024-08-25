using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUi.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<GetDiscountCodeDetail> GetDiscountCode(string code);
    }
}
