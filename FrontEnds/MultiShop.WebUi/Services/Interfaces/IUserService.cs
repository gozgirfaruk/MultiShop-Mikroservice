using MultiShop.WebUi.Models;

namespace MultiShop.WebUi.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
