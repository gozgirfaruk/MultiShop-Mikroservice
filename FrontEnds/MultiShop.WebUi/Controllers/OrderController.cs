using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.AdressesDtos;
using MultiShop.WebUi.Services.Interfaces;
using MultiShop.WebUi.Services.OrderServices.AdressService;

namespace MultiShop.WebUi.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;

        public OrderController(IAddressService addressService, IUserService userService)
        {
            _addressService = addressService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateAddressDto createAddressDto)
        {
            var values = await _userService.GetUserInfo();
            createAddressDto.UserID = values.Id;
            await _addressService.CreateOrderAddressAsync(createAddressDto);
            return RedirectToAction("Index", "Payment");
        }
    }
}
