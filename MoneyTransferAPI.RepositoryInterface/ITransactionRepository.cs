using MoneyTransferAPI.Core.Entities;
using MoneyTransferAPI.Interface.DataAccess;

namespace MoneyTransferAPI.RepositoryInterface
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
    }
}