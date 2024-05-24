using Microsoft.EntityFrameworkCore;
using PiggyPalAPI.Data;
using PiggyPalAPI.Interfaces;
using PiggyPalAPI.Models;

namespace PiggyPalAPI.Repositories
{
    public class CategoriesRepository: ICategoriesRepository
    {
        private readonly PiggyPalDbContext _context;

        public CategoriesRepository(PiggyPalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<CategoryModel> GetCategory(int id)
        {

            return await _context.Categories.FindAsync(id) ?? throw new Exception("Category not found");
        }

        public async Task AddCategory(CategoryModel category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategory(CategoryModel category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Category not found");
            }

        }
    }
}
