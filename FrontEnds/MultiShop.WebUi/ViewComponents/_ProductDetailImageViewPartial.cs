using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.ViewComponents
{
    public class _ProductDetailImageViewPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductDetailImageViewPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:7186/api/Products/GetProductById?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonObject = JsonConvert.DeserializeObject<GetByIdProductImageDto>(jsonData);

                if (jsonObject != null)
                {
                    string productId = jsonObject.ProductID;

                    var responseMessage2 = await client.GetAsync($"http://localhost:7186/api/ProductImages/GetProductImageById/{productId}");
                    if (responseMessage2.IsSuccessStatusCode)
                    {
                        var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                        var jsonObject2 = JsonConvert.DeserializeObject<UpdateProductImageDto> (jsonData2);
                        return View(jsonObject2);
                    }
                }

            }
            return View();
        }
    }
}
