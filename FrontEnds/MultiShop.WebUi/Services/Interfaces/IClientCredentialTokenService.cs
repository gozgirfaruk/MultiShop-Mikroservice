namespace MultiShop.WebUi.Services.Interfaces
{
    public interface IClientCredentialTokenService
    {
        Task<string> GetTokenAsync();
    }
}
