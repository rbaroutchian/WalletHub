using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletHub.Interfaces;
using WalletHub.Models;

namespace WalletHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _configuration;

        public LoginController(ILoginService loginService, IConfiguration configuration)
        {
            _loginService = loginService;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            // احراز هویت
            bool isAuthenticated = _loginService.Authenticate(login.LoginUsername);

            if (isAuthenticated)
            {
                // تولید توکن
                string token = _loginService.GenerateToken(login.LoginUsername);

                // بازگشت توکن به عنوان نتیجه
                return Ok(new { token = token });
            }
            else
            {
                // احراز هویت ناموفق بوده است
                return Unauthorized("Authentication failed");
            }
        }
    }
}
