namespace MultiShop.SignalRealTime.Services
{
    public interface ISignalrCommentService
    {
        Task<int> GetTotalCommentCount();
    }
}
