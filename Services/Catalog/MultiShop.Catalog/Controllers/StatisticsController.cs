using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.StatisticServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var values =await _statisticService.GetBrandCount(); 
            return Ok(values);
        }

        [HttpGet("GetCategoryCount")]
        public async Task<IActionResult> GetCategoryCount()
        {
            var values = await _statisticService.GetCategoryCount();
            return Ok(values);
        }

        [HttpGet("GetProductCount")]
        public async Task<IActionResult> GetProductCount()
        {
            var values = await _statisticService.GetProductCount();
            return Ok(values);
        }
        [HttpGet("GetProductAvgPrice")]
        public async Task<IActionResult> GetProductAvgPrice()
        {
            var values = await _statisticService.GetProductAvgPrice();
            return Ok(values);
        }
        [HttpGet("GetProductMaxPrice")]
        public async Task<IActionResult> GetProductMaxPrice()
        {
            var values = await _statisticService.GetProductMaxPrice();
            return Ok(values);
        }
        [HttpGet("GetProductMinPrice")]
        public async Task<IActionResult> GetProductMinPrice()
        {
            var values = await _statisticService.GetProductMinPrice();
            return Ok(values);
        }
    }
}
