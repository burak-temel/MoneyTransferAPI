using MediatR;
using AutoMapper;
using MoneyTransferAPI.RepositoryInterface;
using MoneyTransferAPI.Core.Queries.User;
using MoneyTransferAPI.Enums;

namespace MoneyTransferAPI.Business.Handlers.Command.User
{
    public class UpdateUserBalanceCommandHandler : IRequestHandler<UpdateUserBalanceCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        // Diğer bağımlılıklar...

        public UpdateUserBalanceCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            // Diğer bağımlılıkların atanması...
        }

        public async Task<bool> Handle(UpdateUserBalanceCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(command.UserId);

            if (command.Operation == BalanceOperation.Increase)
            {
                user.Balance += command.TransactionAmount;
            }
            else
            {
                user.Balance -= command.TransactionAmount;
            }

            await _userRepository.UpdateAsync(user);

            return true;
        }
    }
}
