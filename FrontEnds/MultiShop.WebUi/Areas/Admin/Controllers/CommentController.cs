using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CommentList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7061/api/Comments");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonObject = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(jsonObject);
            }
            return View();
        }
        [Route("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7061/api/Comments?id={id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CommentList");
            }
            return View();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7061/api/Comments/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonObject = JsonConvert.DeserializeObject<GetCommentById>(jsonData);
                return View(jsonObject);
            }
            return View();
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> GetCommentById(UpdateCommentDto dto)
        {
            dto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content= new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7061/api/Comments",content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CommentList");
            }
            return View();
        }
    }
}
