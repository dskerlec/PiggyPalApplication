using PiggyPalAPI.Models;

namespace PiggyPalAPI.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<CategoryModel>> GetCategories();
        Task<CategoryModel> GetCategory(int id);
        Task AddCategory(CategoryModel category);
        Task UpdateCategory(CategoryModel category);
        Task DeleteCategory(int id);
    }
}
