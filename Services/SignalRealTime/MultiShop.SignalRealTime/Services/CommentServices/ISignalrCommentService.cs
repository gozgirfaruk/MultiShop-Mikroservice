namespace MultiShop.SignalRealTime.Services.CommentServices
{
    public interface ISignalrCommentService
    {
        Task<int> GetTotalCommentCount();
    }
}
