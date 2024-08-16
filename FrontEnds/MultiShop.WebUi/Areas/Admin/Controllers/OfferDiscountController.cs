using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;
using NuGet.Versioning;
using System.Text;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OfferDiscount/[action]")]
    public class OfferDiscountController : Controller
    {
        private readonly  IHttpClientFactory _httpClientFactory;

        public OfferDiscountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> OfferDiscountList()
        {
          
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7186/api/OfferDiscounts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonObject = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
                return View(jsonObject);
            }

            return View();
        }
        [Route("{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:7186/api/OfferDiscounts?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("OfferDiscountList");
            }
           
            return View();
        }
        [HttpGet]
        public IActionResult CreateOfferDiscount()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:7186/api/OfferDiscounts", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("OfferDiscountList");
            }
            return View();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:7186/api/OfferDiscounts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonObject = JsonConvert.DeserializeObject<GetOfferDiscountByIdDto>(jsonData);
                return View(jsonObject);
            }
            return View();
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("http://localhost:7186/api/OfferDiscounts", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("OfferDiscountList");
            }
            return View();

        }
    }
}
