using MediatR;
using MoneyTransferAPI.Core.Commands.User;
using MoneyTransferAPI.Core.DTOs.User;
using AutoMapper;
using MoneyTransferAPI.Infrastructure.Authentication;
using MoneyTransferAPI.RepositoryInterface;

namespace MoneyTransferAPI.Business.Handlers.Command.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        // Diğer bağımlılıklar...

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            // Diğer bağımlılıkların atanması...
        }

        public async Task<UserDto> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            HashingHelper.CreatePasswordHash(command.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new Core.Entities.User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Balance = 100,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                DateCreated = DateTime.UtcNow,
                Status = true,
                Currency = command.Currency
            };

            await _userRepository.AddAsync(user);

            return _mapper.Map<UserDto>(user);
        }
    }
}
