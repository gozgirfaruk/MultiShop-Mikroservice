using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsContoller : ControllerBase
    {
        private readonly ICouponService _couponService;
        public CouponsContoller(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet]
        public async Task<IActionResult> CouponList()
        {
            var values = await _couponService.GetCouponAllListAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> InsertCoupon(CreateCouponDto createCouponDto)
        {
            await _couponService.CreateCouponAsync(createCouponDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await _couponService.UpdateCouponAsync(updateCouponDto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await _couponService.DeleteCouponAsync(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponById(int id)
        {
            var value = await _couponService.GetCouponById(id);
            return Ok(value);
        }
    }
}
