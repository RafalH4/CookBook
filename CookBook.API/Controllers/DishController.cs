using CookBook.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CookBook.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _service;
        public DishController(IDishService service)
        {
            _service = service;
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> CreateDish()
        {
            return Ok("abc");

        }
    }
}
