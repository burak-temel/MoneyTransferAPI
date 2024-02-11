using MediatR;
using MoneyTransferAPI.Core.Commands.User;
using MoneyTransferAPI.Core.DTOs.User;
using MoneyTransferAPI.Interface.Repositories;
using AutoMapper;

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
            var user = new Core.Entities.User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                // Diğer alanların atanması...
            };

            // Kullanıcı oluşturma işlemleri...
            await _userRepository.AddAsync(user);

            return _mapper.Map<UserDto>(user);
        }
    }

}
