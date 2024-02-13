using Moq;
using MoneyTransferAPI.Business.Handlers.Command.User;
using MoneyTransferAPI.RepositoryInterface;
using MoneyTransferAPI.Core.Queries.User;
using AutoMapper;

namespace MoneyTransferAPI.Tests.Handlers.Command.User
{

    namespace MoneyTransferAPI.Tests.Handlers.Command.User
    {
        public class UpdateUserBalanceCommandHandlerTests
        {
            private readonly Mock<IUserRepository> _mockUserRepository;
            private readonly Mock<IMapper> _mockMapper;
            private readonly UpdateUserBalanceCommandHandler _handler;

            public UpdateUserBalanceCommandHandlerTests()
            {
                _mockUserRepository = new Mock<IUserRepository>();
                _mockMapper = new Mock<IMapper>();
                _handler = new UpdateUserBalanceCommandHandler(_mockUserRepository.Object, _mockMapper.Object);
            }

            //[Fact]
            //public async Task Handle_GivenValidCommand_ShouldUpdateUserBalance()
            //{
            //    var updateBalanceCommand = new UpdateUserBalanceCommand
            //    {
            //};

            //    _mockUserRepository.Setup(repo => repo.Upda(It.IsAny<Guid>(), It.IsAny<decimal>()))
            //                       .Returns(Task.CompletedTask);

            //    var result = await _handler.Handle(updateBalanceCommand, new CancellationToken());

            //}

        }
    }
}