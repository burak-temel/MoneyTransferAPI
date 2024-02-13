using MediatR;
using MoneyTransferAPI.Core.DTOs.Transaction;
using MoneyTransferAPI.Core.Generals;

namespace MoneyTransferAPI.Core.Queries.Transaction
{
    public class GetTransactionByIdQuery : IRequest<Response<TransactionDto>>
    {
        public Guid TransactionId { get; set; }
    }
}
