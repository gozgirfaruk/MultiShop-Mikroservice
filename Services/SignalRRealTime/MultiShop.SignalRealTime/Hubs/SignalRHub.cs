using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRealTime.Services;

namespace MultiShop.SignalRealTime.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalrCommentService _commentService;

        public SignalRHub(ISignalrCommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task SendStatisticCount()
        {
            var value = _commentService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiverCommentCount", value);
        }
    }
}
