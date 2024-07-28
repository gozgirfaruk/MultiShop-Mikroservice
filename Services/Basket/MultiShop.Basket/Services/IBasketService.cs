using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketList(string userId);
        Task SaveBasket(BasketTotalDto baskettotalDto);
        Task DeleteBasket(string userId);

    }
}
