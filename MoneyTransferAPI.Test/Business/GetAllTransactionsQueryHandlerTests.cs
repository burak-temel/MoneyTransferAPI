using Moq;
using MoneyTransferAPI.RepositoryInterface;
using MoneyTransferAPI.Business.Handlers.Query.Transaction;
using MoneyTransferAPI.Core.DTOs.Transaction;
using MoneyTransferAPI.Core.Queries.Transaction;
using AutoMapper;
using System.Transactions;

namespace MoneyTransferAPI.Tests.Handlers.Command.User
{
    public class GetAllTransactionsQueryHandlerTests
    {
        private readonly Mock<ITransactionRepository> _mockTransactionRepository;
        private readonly GetAllTransactionsQueryHandler _handler;
        private readonly Mock<IMapper> _mockMapper;

        public GetAllTransactionsQueryHandlerTests()
        {
            _mockTransactionRepository = new Mock<ITransactionRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new GetAllTransactionsQueryHandler(_mockTransactionRepository.Object, _mockMapper.Object);
        }

        //[Fact]
        //public async Task Handle_GivenValidQuery_ShouldReturnTransactions()
        //{
        //    var getAllTransactionsQuery = new GetAllTransactionsQuery();
        //    var transactions = new List<Transaction> {  };

        //    //TODO

        //    //_mockTransactionRepository.Setup(repo => repo.GetAllAsync())
        //    //                          .ReturnsAsync(transactions);

        //    var transactionDtos = transactions.Select(t => new TransactionDto() ).ToList();

        //    _mockMapper.Setup(mapper => mapper.Map<IEnumerable<TransactionDto>>(It.IsAny<IEnumerable<Transaction>>()))
        //               .Returns(transactionDtos);

        //    var result = await _handler.Handle(getAllTransactionsQuery, new CancellationToken());

        //    Assert.NotNull(result);
        //    Assert.Equal(transactions.Count, result.Count());
        //}

    }

}
