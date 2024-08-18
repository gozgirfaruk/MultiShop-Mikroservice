using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUi.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContact)
        {


            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContact);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:7186/api/Contacts", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("HomePage", "Home");
            }
            return View();
        }
    }
}
