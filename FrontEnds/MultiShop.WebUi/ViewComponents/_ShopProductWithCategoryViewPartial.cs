using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.ViewComponents
{
    public class _ShopProductWithCategoryViewPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ShopProductWithCategoryViewPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
           
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:7186/api/Products/ProductListWithCategoryById?id={id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();   
                var jsonObject = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(jsonObject);
            }
            return View();
        }
    }
}
