using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartAPI.Data;
using ShoppingCartAPI.Interface;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.Repository;

namespace ShoppingCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
       
        private readonly DataContext _dbContext;
        public ProductController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product object is null");
            }

            await productService.InsertProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.productId }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (product == null || product.productId != id)
            {
                return BadRequest("Invalid product object");
            }

            var existingProduct = await productService.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            await productService.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            await productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
