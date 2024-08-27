using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.Interfaces;
using MultiShop.WebUi.Services.UserIdentityServices;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
       private readonly IUserIdentityService _userIdentityService;

        public UserController(IUserIdentityService userIdentityService)
        {
            _userIdentityService = userIdentityService;
        }

        public async Task<IActionResult> UserList()
        {
            var values = await _userIdentityService.GetAllUserListAsync();
            return View(values);
        }
    }
}
