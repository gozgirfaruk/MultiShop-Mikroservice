using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterDto registerDto)
        {
            var values = new ApplicationUser()
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Name = registerDto.Name,
                Surname = registerDto.Surname
            };
            var result = await _userManager.CreateAsync(values, registerDto.Password);
            if (result.Succeeded)
            {
                return Ok("Kullanıcı Başarı ile eklendi");
            }
            else
            {
                return Ok("Kayıt sırasında bir hata meydana geldi. Tekrar deneyiniz.");
            }
        }
    }
}
