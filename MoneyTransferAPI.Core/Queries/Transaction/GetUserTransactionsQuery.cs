using MediatR;
using MoneyTransferAPI.Core.DTOs.Transaction;
using MoneyTransferAPI.Core.Generals;

namespace MoneyTransferAPI.Core.Queries.Transaction
{
    public class GetUserTransactionsQuery : IRequest<Response<IEnumerable<TransactionDto>>>
    {
        public Guid UserId { get; set; }
    }
}
