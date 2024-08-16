using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.ViewComponents
{
    public class _NavbarViewPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _NavbarViewPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7186/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonObject = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(jsonObject);
            }
            return View();
        }
    }
}
