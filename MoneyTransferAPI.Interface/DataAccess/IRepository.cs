using System.Linq.Expressions;

namespace MoneyTransferAPI.Interface.DataAccess
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
