using MultiShop.DtoLayer.IdentityDtos.LoginDtos;

namespace MultiShop.WebUi.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signInDto);
        Task<bool> GetRefreshToken();
    }
}
