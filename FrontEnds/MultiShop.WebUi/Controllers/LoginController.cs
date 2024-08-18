using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUi.Models;
using MultiShop.WebUi.Services.Interfaces;
using MultiShop.WebUi.Services.LoginServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace MultiShop.WebUi.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly IIdentityService _identityService;
        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _identityService = identityService;
        }



        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            signInDto.Username = "gozgirfaruk";
            signInDto.Password = "Saat1212.*";
            await _identityService.SignIn(signInDto);
            return RedirectToAction("HomePage", "Home");
        }
    }
}
