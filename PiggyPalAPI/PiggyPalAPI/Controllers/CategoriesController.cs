using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PiggyPalAPI.Data;
using PiggyPalAPI.Interfaces;
using PiggyPalAPI.Models;

namespace PiggyPalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;
        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetCategories()
        {
            return Ok(await _categoriesRepository.GetCategories());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CategoryModel>>> GetById(int id)
        {
            return Ok(await _categoriesRepository.GetCategory(id));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, CategoryModel category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            var categoryToUpdate = await _categoriesRepository.GetCategory(id);
            if (categoryToUpdate == null)
            {
                return NotFound();
            }

            await _categoriesRepository.UpdateCategory(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var categoryToDelete = await _categoriesRepository.GetCategory(id);
            if (categoryToDelete == null)
            {
                return NotFound();
            }

            await _categoriesRepository.DeleteCategory(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CategoryModel>> AddCategory(CategoryModel category)
        {
            await _categoriesRepository.AddCategory(category);
            return CreatedAtAction(nameof(GetById), new { id = category.CategoryId }, category);
        }
    }
}
