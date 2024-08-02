using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/[controller]/[action]")]
    public class FeatureSliderController : Controller
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:7186/api/FeatureSliders");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetFeatureSliderDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateFeatureSlider()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto dto)
        {
            dto.Status = false;
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await _httpClient.PostAsync("http://localhost:7186/api/FeatureSliders", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"http://localhost:7186/api/FeatureSliders/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values =JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto dto)
        {
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent stringContent =new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await _httpClient.PutAsync("http://localhost:7186/api/FeatureSliders", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"http://localhost:7186/api/FeatureSliders?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
