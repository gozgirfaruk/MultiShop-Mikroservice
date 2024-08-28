using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserMessageController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessageController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }


        [HttpGet("GetInbox")]
        public async Task<IActionResult> GetInbox(string id)
        {
            var values = await _userMessageService.GetAllInboxAsync(id);
            return Ok(values);
        }

        [HttpGet("GetSendbox")]
        public async Task<IActionResult> GetSendbox(string id)
        {
            var values = await _userMessageService.GetAllSendboxAsync(id);
            return Ok(values);
        }
        [HttpGet("GetMessageById")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            var values = await _userMessageService.GetMessageByIdDto(id);
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _userMessageService.DeleteMessageAsync(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto messageDto)
        {
            await _userMessageService.CreateMessageAsync(messageDto);
            return Ok();
        }

        [HttpGet("GetTotalMessageCount")]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            var values = await _userMessageService.GetTotalMessageCount();
            return Ok(values);
        }
    }
}
