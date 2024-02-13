using AutoMapper;
using MediatR;
using MoneyTransferAPI.Core.Commands.Transaction;
using MoneyTransferAPI.Core.DTOs.Transaction;
using MoneyTransferAPI.RepositoryInterface;

namespace MoneyTransferAPI.Business.Handlers.Command.Transaction
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, TransactionResultDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        // Diğer bağımlılıklar...

        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<TransactionResultDto> Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
        {
            // Para transfer işlemi mantığı...

            var transaction = new Core.Entities.Transaction
            {
                SenderId = command.SenderId,
                ReceiverId = command.ReceiverId,
                Amount = command.Amount,
                // Diğer alanların atanması...
            };

            await _transactionRepository.AddAsync(transaction);

            return new TransactionResultDto
            {
                Success = true,
                // Diğer sonuç bilgileri...
            };
        }
    }

}
