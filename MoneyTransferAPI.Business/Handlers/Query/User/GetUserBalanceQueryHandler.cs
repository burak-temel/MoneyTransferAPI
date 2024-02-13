using MediatR;
using MoneyTransferAPI.Core.Generals;
using MoneyTransferAPI.Core.Queries.User;
using MoneyTransferAPI.RepositoryInterface;

namespace MoneyTransferAPI.Business.Handlers.Query.User
{

    public class GetUserBalanceQueryHandler : IRequestHandler<GetUserBalanceQuery, Response<decimal>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserBalanceQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response<decimal>> Handle(GetUserBalanceQuery query, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(query.UserId);

            if (user == null)
            {
                return Response<decimal>.Fail("User not found");
            }

            return Response<decimal>.Success(user.Balance);
        }
    }


}
