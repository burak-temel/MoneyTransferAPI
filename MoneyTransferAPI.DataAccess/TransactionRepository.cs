using Microsoft.EntityFrameworkCore;
using MoneyTransferAPI.Core.Entities;
using MoneyTransferAPI.Interface.Entities;
using MoneyTransferAPI.RepositoryInterface;
using System.Linq.Expressions;

namespace MoneyTransferAPI.DataAccess
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction> GetByIdAsync(Guid id)
        {
            return await _context.Transactions.FindAsync(id);
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Transaction transaction)
        {
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }

        public Task<Transaction> GetAsync(Expression<Func<Transaction, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }

}
