using MultiShop.Catalog.Dtos.AboutDtos;

namespace MultiShop.Catalog.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAboutListAsync();
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        Task<GetAboutByIdDto> GetAboutByIdAsync(string id);
        Task CreateAboutAsync(CreateAboutDto createAboutDto);
    }
}
