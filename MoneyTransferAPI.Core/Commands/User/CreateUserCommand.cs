using MediatR;
using MoneyTransferAPI.Core.DTOs.User;

namespace MoneyTransferAPI.Core.Commands.User
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

}
