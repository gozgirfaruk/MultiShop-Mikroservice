using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRealTime.Services.CommentServices;

namespace MultiShop.SignalRealTime.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalrCommentService _signalRService;

        public SignalRHub(ISignalrCommentService signalRService)
        {
            _signalRService = signalRService;
        }
    }
}
