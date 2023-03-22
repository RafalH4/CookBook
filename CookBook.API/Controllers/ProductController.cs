using CookBook.Models.DTO.Product;
using CookBook.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMainProductService _service;
        public ProductController(IMainProductService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> AddMainProduct([FromBody] NewProductModel model)
        {
            var product = await _service.AddProductAsync(model);
            if (product.Success)
            {
                return Ok(product.Messages);
            }
            else
            {
                return BadRequest(product.Messages);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Products()
        {
            var products = await _service.AllProducts();
            return Ok(products.Data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _service.GetProduct(id);
            return Ok(product);
        }

    }
}
