using Microsoft.EntityFrameworkCore;
using MoneyTransferAPI.Interface.DataAccess;
using MoneyTransferAPI.Interface.Entities;
using MoneyTransferAPI.Interface.Repositories;
using System.Linq.Expressions;

namespace MoneyTransferAPI.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IUser> GetByIdAsync(Guid id)
        {
            return await _context.Set<IUser>().FindAsync(id);
        }


        public async Task<IEnumerable<IUser>> GetAllAsync()
        {
            return await _context.Set<IUser>().ToListAsync();
        }

        public async Task AddAsync(IUser user)
        {
            await _context.Set<IUser>().AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(IUser user)
        {
            _context.Set<IUser>().Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(IUser user)
        {
            _context.Set<IUser>().Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IUser> GetAsync(Expression<Func<IUser, bool>> expression)
        {
            return await _context.Set<IUser>().AsQueryable().FirstOrDefaultAsync(expression);
        }
    }

}
