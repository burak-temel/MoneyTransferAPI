using MediatR;
using MoneyTransferAPI.Core.DTOs.User;

namespace MoneyTransferAPI.Core.Queries.User
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public Guid UserId { get; set; }
    }

}
