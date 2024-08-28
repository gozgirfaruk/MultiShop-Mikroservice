using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponService _couponService;
        public CouponsController(ICouponService couponService)
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

        [HttpGet("GetCodeDetail")]
        public async Task<IActionResult> GetCodeDetail(string code)
        {
            var value = await _couponService.GetCodeDetail(code);
            return Ok(value);
        }

        [HttpGet("GetCouponCount")]
        public async Task<IActionResult> GetCouponCount()
        {
            var value = await _couponService.GetCouponCount();
            return Ok(value);
        }
    }
}
