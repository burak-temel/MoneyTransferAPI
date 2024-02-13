using MediatR;
using MoneyTransferAPI.Core.DTOs.User;
using MoneyTransferAPI.Enums;

namespace MoneyTransferAPI.Core.Queries.User
{
    public class UpdateUserBalanceCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionCurrency { get; set; }
        public BalanceOperation Operation { get; set; }
    }
}
