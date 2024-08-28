using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUi.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _statisticService;
        private readonly IUserStatisticService _userStatisticService;
        public StatisticController(ICatalogStatisticService statisticService, IUserStatisticService userStatisticService)
        {
            _statisticService = statisticService;
            _userStatisticService = userStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.BrandCount= await _statisticService.GetBrandCount();
            ViewBag.CategoryCount = await _statisticService.GetCategoryCount();
            ViewBag.ProductCount = await _statisticService.GetProductCount();
            ViewBag.MaxPrice = await _statisticService.GetProductMaxPrice();
            ViewBag.MinPrice = await _statisticService.GetProductMinPrice();
            ViewBag.UserCount = await _userStatisticService.GetUserCount();


            return View();
        }
    }
}
