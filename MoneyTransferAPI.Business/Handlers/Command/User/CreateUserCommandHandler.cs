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
            // Create password hash and salt
            HashingHelper.CreatePasswordHash(command.Password, out byte[] passwordHash, out byte[] passwordSalt);

            // Create new user with hashed password
            var user = new Core.Entities.User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Balance = 100,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                DateCreated = DateTime.UtcNow,
                Status = true
            };

            // Save the new user
            await _userRepository.AddAsync(user);

            // Return the DTO mapping
            return _mapper.Map<UserDto>(user);
        }
    }

}
