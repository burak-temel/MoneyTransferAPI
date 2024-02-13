using MediatR;
using MoneyTransferAPI.Core.Entities;
using MoneyTransferAPI.Core.Queries.User;
using MoneyTransferAPI.RepositoryInterface;

namespace MoneyTransferAPI.Business.Handlers.Query.User
{
    public class CheckUserBalanceQueryHandler : IRequestHandler<CheckUserBalanceQuery, bool>
    {
        private readonly IUserRepository _userRepository;

        public CheckUserBalanceQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(CheckUserBalanceQuery request, CancellationToken cancellationToken)
        {
            //Farklı kontroller eklenebilir.

            if (request != null && request.TransactionAmount >= 0 && request.User.Balance >= request.TransactionAmount)
            {
                return true;
            }

            return false;
        }

    }
}