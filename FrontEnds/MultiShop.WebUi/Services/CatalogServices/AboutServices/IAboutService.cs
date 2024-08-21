using MultiShop.DtoLayer.CatalogDtos.AboutDtos;

namespace MultiShop.WebUi.Services.CatalogServices.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAboutListAsync();
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task<UpdateAboutDto> GetAboutByIdAsync(string id);
    }
}
