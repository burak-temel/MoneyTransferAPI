using MediatR;
using MoneyTransferAPI.Core.DTOs.User;

namespace MoneyTransferAPI.Core.Queries.User
{
    public class CheckUserBalanceQuery : IRequest<bool>
    {
        public UserDto User { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionCurrency { get; set; }
    }
}
