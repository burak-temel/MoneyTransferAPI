using Moq;
using MoneyTransferAPI.RepositoryInterface;
using MoneyTransferAPI.Core.Queries.User;
using MoneyTransferAPI.Business.Handlers.Query.User;
using MoneyTransferAPI.Core.DTOs.User;

namespace MoneyTransferAPI.Tests.Handlers.Query.User
{
    public class CheckUserBalanceQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly CheckUserBalanceQueryHandler _handler;

        public CheckUserBalanceQueryHandlerTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _handler = new CheckUserBalanceQueryHandler(_mockUserRepository.Object);
        }


        [Fact]
        public async Task Handle_SufficientBalance_ShouldReturnTrue()
        {
            var userDto = new UserDto
            {
                Balance = 200m,
            };

            var query = new CheckUserBalanceQuery
            {
                User = userDto,
                TransactionAmount = 100m,
                TransactionCurrency = "USD" 
            };

            var result = await _handler.Handle(query, CancellationToken.None);

            Assert.True(result);
        }

        [Fact]
        public async Task Handle_InsufficientBalance_ShouldReturnFalse()
        {
            var userDto = new UserDto
            {
                Balance = 200m,
            };

            var query = new CheckUserBalanceQuery
            {
                User = userDto,
                TransactionAmount = 300m,
                TransactionCurrency = "USD" 
            };

            var result = await _handler.Handle(query, CancellationToken.None);

            Assert.False(result);
        }
    }
}


