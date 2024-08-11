using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.ViewComponents
{
    public class _OfferViewPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _OfferViewPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7186/api/OfferDiscounts");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();   
                var jsonObject = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
                return View(jsonObject);
            }
            return View();
        }
    }
}
