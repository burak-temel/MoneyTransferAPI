using Microsoft.EntityFrameworkCore;
using MoneyTransferAPI.Core.Entities;
using MoneyTransferAPI.Interface.Entities;
using MoneyTransferAPI.Interface.Repositories;

namespace MoneyTransferAPI.DataAccess
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DbContext _context;

        public TransactionRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<ITransaction> GetByIdAsync(Guid id)
        {
            return await _context.Set<ITransaction>().FindAsync(id);
        }

        public async Task<IEnumerable<ITransaction>> GetAllAsync()
        {
            return await _context.Set<ITransaction>().ToListAsync();
        }

        public async Task AddAsync(ITransaction transaction)
        {
            await _context.Set<ITransaction>().AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ITransaction transaction)
        {
            _context.Set<ITransaction>().Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ITransaction transaction)
        {
            _context.Set<ITransaction>().Remove(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
