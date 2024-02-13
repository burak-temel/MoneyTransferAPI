using AutoMapper;
using MediatR;
using MoneyTransferAPI.Core.Commands.Transaction;
using MoneyTransferAPI.Core.DTOs.Transaction.Response;
using MoneyTransferAPI.Core.Generals;
using MoneyTransferAPI.Core.Queries.User;
using MoneyTransferAPI.Enums;
using MoneyTransferAPI.RepositoryInterface;

namespace MoneyTransferAPI.Business.Handlers.Command.Transaction
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Response<CreateTransactionResponse>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IMapper mapper, IMediator mediator)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Response<CreateTransactionResponse>> Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
        {
            // Alıcı ve göndericiyi kontrol et
            var sender = await _mediator.Send(new GetUserByIdQuery { UserId = command.SenderId });
            var receiver = await _mediator.Send(new GetUserByIdQuery { UserId = command.ReceiverId });

            if (sender == null || receiver == null)
            {
                return Response<CreateTransactionResponse>.Fail("Sender or receiver not found");
            }

            // Göndericinin yeterli bakiyesi var mı kontrol et
            bool hasEnoughBalance = await _mediator.Send(new CheckUserBalanceQuery
            {
                User = sender,
                TransactionAmount = command.Amount,
                TransactionCurrency = command.Currency
            });

            if (!hasEnoughBalance)
            {
                return Response<CreateTransactionResponse>.Fail("Sender does not have enough balance");
            }

            //Update user balance
            await _mediator.Send(new UpdateUserBalanceCommand
            {
                UserId = command.SenderId,
                TransactionAmount = command.Amount,
                TransactionCurrency = command.Currency,
                Operation = BalanceOperation.Decrease
            });

            //update receiver balance

            await _mediator.Send(new UpdateUserBalanceCommand
            {
                UserId = command.ReceiverId,
                TransactionAmount = command.Amount,
                TransactionCurrency = command.Currency,
                Operation = BalanceOperation.Increase
            });

            var transaction = new Core.Entities.Transaction
            {
                SenderId = command.SenderId,
                ReceiverId = command.ReceiverId,
                Amount = command.Amount,
                Currency = command.Currency,
                TransactionDate = DateTime.UtcNow
            };

            await _transactionRepository.AddAsync(transaction);

            return Response<CreateTransactionResponse>.Success(new CreateTransactionResponse
            {
                Id = transaction.Id
            });
        }
    }

}
