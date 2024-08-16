using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUi.ViewComponents
{
    public class _AboutViewPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutViewPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7186/api/Abouts");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();   
                var jsonObject = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(jsonObject);
            }
            return View();
        }
    }
}
