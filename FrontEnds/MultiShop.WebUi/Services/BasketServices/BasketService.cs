using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUi.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task DeleteBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDto> GetBasketList()
        {
            var responseMessage = await _httpClient.GetAsync("baskets");
            var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            return values;
        }

        public async Task SaveBasket(BasketTotalDto baskettotalDto)
        {
            await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", baskettotalDto);
        }

        public async Task AddBasketItem(BasketItemDto basketitemDto)
        {
            var values = await GetBasketList();
            if(values != null)
            {
                if (!values.BasketItems.Any(x => x.ProductID == basketitemDto.ProductID))
                {
                 
                    values.BasketItems.Add(basketitemDto);
                }
                else
                {
                    basketitemDto.Quantity += 1;
                    values.BasketItems.Add(basketitemDto);
                }

                await SaveBasket(values);
            }
        }
        public async Task<bool> RemoveBasketItem(string productId)
        {
            var values = await GetBasketList();
            var deletedItem = values.BasketItems.FirstOrDefault(x=>x.ProductID== productId);
            var result = values.BasketItems.Remove(deletedItem);
            await SaveBasket(values);
            return true;
        }
    }
}
