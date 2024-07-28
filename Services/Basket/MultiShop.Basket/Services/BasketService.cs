using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            var status = await _redisService.GetDB().KeyDeleteAsync(userId);

        }

        public async Task<BasketTotalDto> GetBasketList(string userId)
        {
           var existBasket= await _redisService.GetDB().StringGetAsync(userId);
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }

        public async Task SaveBasket(BasketTotalDto baskettotalDto)
        {
            await _redisService.GetDB().StringSetAsync(baskettotalDto.UserID, JsonSerializer.Serialize(baskettotalDto));
        }
    }
}
