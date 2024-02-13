using MediatR;
using MoneyTransferAPI.Core.Generals;

namespace MoneyTransferAPI.Core.Queries.User
{
    public class GetUserBalanceQuery : IRequest<Response<decimal>>
    {
        public Guid UserId { get; set; }
    }
}
