using MediatR;
using MoneyTransferAPI.Core.DTOs.User;
using MoneyTransferAPI.Core.DTOs.User.Response;
using MoneyTransferAPI.Core.Generals;

namespace MoneyTransferAPI.Core.Queries.User
{
    public class UserLoginQuery : IRequest<Response<LoginResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
