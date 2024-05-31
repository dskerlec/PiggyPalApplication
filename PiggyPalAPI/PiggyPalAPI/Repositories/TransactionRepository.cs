using Microsoft.EntityFrameworkCore;
using PiggyPalAPI.Data;
using PiggyPalAPI.Interfaces;
using PiggyPalAPI.Models;

namespace PiggyPalAPI.Repositories
{
    public class TransactionRepository: ITransactionRepository
    {
        private readonly PiggyPalDbContext _context;

        public TransactionRepository(PiggyPalDbContext context)
        {
            _context = context;
        }

        public async Task Add(TransactionModel transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Transaction not found");
            }
        }

        public async Task<IEnumerable<TransactionModel>> GetAll()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<TransactionModel> GetById(int id)
        {
            return await _context.Transactions.FindAsync(id) ?? throw new Exception("Transaction not found");
        }

        public async Task<IEnumerable<TransactionModel>> GetByDate(DateOnly date)
        {
            return await _context.Transactions.Where(t => t.TransactionDate == date).ToListAsync() ?? throw new Exception("Transaction not found");
        }

        public async Task<IEnumerable<TransactionModel>> GetByAmount(decimal amount)
        {
            return await _context.Transactions.Where(t => t.TransactionAmount == amount).ToListAsync() ?? throw new Exception("Transaction not found");
        }

        public async Task<IEnumerable<TransactionModel>> GetByCategory(int categoryId)
        {
            return await _context.Transactions.Where(t => t.CategoryId == categoryId).ToListAsync() ?? throw new Exception("Transaction not found");
        }


        public async Task<IEnumerable<TransactionModel>> GetByDescription(string description)
        {
            return await _context.Transactions.Where(t => t.TransactionDescription.Contains(description)).ToListAsync() ?? throw new Exception("Transaction not found");
        }

        public async Task Update(TransactionModel transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
