using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.Interfaces;
using MultiShop.WebUi.Services.MessageServices;

namespace MultiShop.WebUi.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        public async Task<IActionResult> Inbox()
        {
            var userId = await _userService.GetUserInfo();
            var values = await _messageService.GetAllInboxAsync(userId.Id);
            return View();
        }
    }
}
