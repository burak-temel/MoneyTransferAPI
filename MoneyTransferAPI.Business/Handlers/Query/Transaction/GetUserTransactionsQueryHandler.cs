using AutoMapper;
using MediatR;
using MoneyTransferAPI.Core.DTOs.Transaction;
using MoneyTransferAPI.Core.Generals;
using MoneyTransferAPI.Core.Queries.Transaction;
using MoneyTransferAPI.RepositoryInterface;

namespace MoneyTransferAPI.Business.Handlers.Query.Transaction
{
    public class GetUserTransactionsQueryHandler : IRequestHandler<GetUserTransactionsQuery, Response<IEnumerable<TransactionDto>>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetUserTransactionsQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<TransactionDto>>> Handle(GetUserTransactionsQuery query, CancellationToken cancellationToken)
        {
            var transactions = await _transactionRepository.GetTransactionsByUserIdAsync(query.UserId);
            var transactionDtos = _mapper.Map<List<TransactionDto>>(transactions);
            return Response<IEnumerable<TransactionDto>>.Success(transactionDtos);
        }
    }
}
