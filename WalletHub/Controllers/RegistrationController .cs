using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletHub.Interfaces;
using WalletHub.Models;

namespace WalletHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IConfiguration configuration, IRegistrationService registrationService)
        {
            _configuration = configuration;
            _registrationService = registrationService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(User user)
        {
            bool isRegistered = await _registrationService.RegisterAsync(user);
            if (isRegistered)
            {
                return Ok("Registration successful.");
            }
            else
            {
                return BadRequest("Registration failed.");
            }
        }
    }
}
