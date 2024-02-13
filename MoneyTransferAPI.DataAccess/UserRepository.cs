using Microsoft.EntityFrameworkCore;
using MoneyTransferAPI.Core.Entities;
using MoneyTransferAPI.Interface.DataAccess;
using MoneyTransferAPI.Interface.Entities;
using MoneyTransferAPI.RepositoryInterface;
using System.Linq.Expressions;

namespace MoneyTransferAPI.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }


        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> expression)
        {
            return await _context.Users.AsQueryable().FirstOrDefaultAsync(expression);
        }
    }

}
