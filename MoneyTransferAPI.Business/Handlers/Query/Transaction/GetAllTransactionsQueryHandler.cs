
using AutoMapper;
using MediatR;
using MoneyTransferAPI.Core.DTOs.Transaction;
using MoneyTransferAPI.Core.Queries.Transaction;
using MoneyTransferAPI.Interface.Repositories;

namespace MoneyTransferAPI.Business.Handlers.Query.Transaction
{
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<TransactionDto>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionDto>> Handle(GetAllTransactionsQuery query, CancellationToken cancellationToken)
        {
            var transactions = await _transactionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TransactionDto>>(transactions);
        }
    }

}
