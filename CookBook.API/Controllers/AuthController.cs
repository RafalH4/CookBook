using CookBook.Models.DTO.User;
using CookBook.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            _service = service;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login (UserLogin model)
        {
            var result = await _service.Authenticate(model);
            if(result.Success)
            {
                var token = result.Data;
                return Ok(token);

            }
            else
            {
                return Unauthorized(result.Messages);
            }
        }
    }
}
