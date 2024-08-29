using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.CommentServices;
using MultiShop.WebUi.Services.DiscountServices;
using MultiShop.WebUi.Services.MessageServices;
using MultiShop.WebUi.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUi.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _statisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentService _commentService;
        //private readonly IMessageService _messageService;
        private readonly IDiscountService _discountService;
        public StatisticController(ICatalogStatisticService statisticService, IUserStatisticService userStatisticService, ICommentService commentService, IDiscountService discountService)
        {
            _statisticService = statisticService;
            _userStatisticService = userStatisticService;
            _commentService = commentService;
            _discountService = discountService;
            //_messageService = messageService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.BrandCount= await _statisticService.GetBrandCount();
            ViewBag.CategoryCount = await _statisticService.GetCategoryCount();
            ViewBag.ProductCount = await _statisticService.GetProductCount();
            ViewBag.MaxPrice = await _statisticService.GetProductMaxPrice();
            ViewBag.MinPrice = await _statisticService.GetProductMinPrice();
            ViewBag.UserCount = await _userStatisticService.GetUserCount();
            ViewBag.PassiveComment = await _commentService.GetPassiveCommentCount();
            ViewBag.ActiveComment = await _commentService.GetActiveCommentCount();
            ViewBag.TotalComment = await _commentService.GetTotalCommentCount();
            ViewBag.CouponCount = await _discountService.GetCouponCount();
            //ViewBag.MessageCount = await _messageService.GetTotalMessageCount();
            
            return View();
        }
    }
}
