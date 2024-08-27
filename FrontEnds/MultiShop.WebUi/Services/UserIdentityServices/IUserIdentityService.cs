using MultiShop.DtoLayer.IdentityDtos.UserDtos;

namespace MultiShop.WebUi.Services.UserIdentityServices
{
    public interface IUserIdentityService
    {
        Task<List<ResultUserDto>> GetAllUserListAsync();
    }
}
