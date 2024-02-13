using AutoMapper;
using MediatR;
using MoneyTransferAPI.Core.DTOs.Transaction;
using MoneyTransferAPI.Core.Generals;
using MoneyTransferAPI.Core.Queries.Transaction;
using MoneyTransferAPI.RepositoryInterface;

namespace MoneyTransferAPI.Business.Handlers.Query.Transaction
{
    public class GetTransactionByIdHandler : IRequestHandler<GetTransactionByIdQuery, Response<TransactionDto>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionByIdHandler(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<Response<TransactionDto>> Handle(GetTransactionByIdQuery query, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetByIdAsync(query.TransactionId);
            if (transaction == null)
            {
                return Response<TransactionDto>.Fail("Transaction not found");
            }
            var transactionDto = _mapper.Map<TransactionDto>(transaction);
            return Response<TransactionDto>.Success(transactionDto);
        }
    }
}
