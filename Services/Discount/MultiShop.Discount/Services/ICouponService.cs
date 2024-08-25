using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface ICouponService
    {
        Task<List<ResultCouponDto>> GetCouponAllListAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task DeleteCouponAsync(int couponId);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task<GetCouponByIdDto> GetCouponById(int id);
        Task<ResultCouponDto> GetCodeDetail(string code);   
    }
}
