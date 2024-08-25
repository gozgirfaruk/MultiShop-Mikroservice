using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUi.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketList();
        Task SaveBasket(BasketTotalDto baskettotalDto);
        Task DeleteBasket(string userId);
        Task AddBasketItem(BasketItemDto basketitemDto);
        Task<bool> RemoveBasketItem(string productId);
    }
}
