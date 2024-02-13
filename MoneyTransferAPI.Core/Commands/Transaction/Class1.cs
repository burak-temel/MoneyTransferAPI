using MediatR;
using MoneyTransferAPI.Core.DTOs.Transaction;
using MoneyTransferAPI.Core.Generals;

namespace MoneyTransferAPI.Core.Commands.Transaction
{
    public class CreateTransactionCommand : IRequest<Response<CreateTransactionResponse>>
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
