using MediatR;
using MoneyTransferAPI.Core.DTOs.Transaction;

namespace MoneyTransferAPI.Core.Commands.Transaction
{
    public class CreateTransactionCommand : IRequest<TransactionResultDto>
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public decimal Amount { get; set; }
        // Diğer gerekli alanlar...
    }
}
