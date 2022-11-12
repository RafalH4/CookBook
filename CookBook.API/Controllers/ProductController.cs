using CookBook.Models.DTO.Product;
using CookBook.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMainProductService _service;
        public ProductController(IMainProductService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task AddProduct(NewProductModel model)
        {
            var result = await _service.AddProductAsync(model);
        }
    }
}
