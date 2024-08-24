using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUi.Services.CatalogServices.ContactServices;
using MultiShop.WebUi.Services.CommentServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUi.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IContactService _contactService;
        private readonly ICommentService _commentService;
        public ProductController(IHttpClientFactory httpClientFactory, HttpClient httpClient, IContactService contactService, ICommentService commentService)
        {
            _httpClientFactory = httpClientFactory;
            _contactService = contactService;
            _commentService = commentService;
        }

        public IActionResult Shop(string id)
        {
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.x = id;
            TempData["productid"] = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
           
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto dto)
        {
            dto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            dto.Status = false;
            dto.ImageUrl = "https://cdn.pixabay.com/photo/2018/04/18/18/56/user-3331256_1280.png";
            dto.ProductId = (string)TempData["productid"];
            await _commentService.CreateCommentAsync(dto);
            return RedirectToAction("HomePage", "Home");

            //var client = _httpClientFactory.CreateClient();
            //var jsonData = JsonConvert.SerializeObject(dto);
            //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var responseMessage = await client.PostAsync("https://localhost:7061/api/Comments", content);
            //if (responseMessage.IsSuccessStatusCode)
            //{
                
            //}
            //return View();

        }
    }
}
