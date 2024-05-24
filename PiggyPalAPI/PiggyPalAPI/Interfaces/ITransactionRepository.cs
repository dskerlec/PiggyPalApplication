using PiggyPalAPI.Models;

namespace PiggyPalAPI.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<TransactionModel>> GetAll();
        Task<TransactionModel> GetById(int id);
        Task Add(TransactionModel transaction);
        Task Update(TransactionModel transaction);
        Task Delete(int id);
    }
}
