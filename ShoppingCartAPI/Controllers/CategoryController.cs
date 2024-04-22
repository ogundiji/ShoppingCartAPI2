using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCartAPI.Data;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.Interface;
using ShoppingCartAPI.Repository;

namespace ShoppingCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
            private readonly ICategoryService categoryService;

            public CategoryController(ICategoryService _categoryService)
            {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
            }
       
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var categories = categoryService.GetAllCategories();
            return Ok(categories);
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest("category object is null");
            }

            await categoryService.InsertCategory(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category.categoryId }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            if (category == null || category.categoryId != id)
            {
                return BadRequest("Invalid category object");
            }

            var existingcategory = await categoryService.GetCategoryById(id);
            if (existingcategory == null)
            {
                return NotFound();
            }

            await categoryService.updateCategory(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await categoryService.GetCategoryById(id);
            if (product == null)
            {
                return NotFound();
            }

            await categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
 }