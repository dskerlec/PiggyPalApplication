using PiggyPalAPI.Models;

namespace PiggyPalAPI.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<TransactionModel>> GetAll();
        Task<TransactionModel> GetById(int id);
        Task<IEnumerable<TransactionModel>> GetByDate(DateOnly date);
        Task<IEnumerable<TransactionModel>> GetByAmount(decimal amount);
        Task<IEnumerable<TransactionModel>> GetByCategory(int categoryId);
        //Task<IEnumerable<TransactionModel>> GetByCategoryName(string categoryName);
        Task<IEnumerable<TransactionModel>> GetByDescription(string description);
        Task Add(TransactionModel transaction);
        Task Update(TransactionModel transaction);
        Task Delete(int id);
    }
}
