using CookBook.Models.DTO.User;
using CookBook.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(NewUser model)
        {
            var result = await _service.NewUser(model);
            if (result.Success)
            {
                return Ok(result.Messages);
            }
            else
            {
                return BadRequest(result.Messages);
            }
        }
    }
}
