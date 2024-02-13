using Xunit;
using Moq;
using MoneyTransferAPI.Business.Handlers.Command.User;
using MoneyTransferAPI.Core.Commands.User;
using MoneyTransferAPI.RepositoryInterface;
using AutoMapper;
using MoneyTransferAPI.Core.DTOs.User;
using MoneyTransferAPI.Core.Entities;

namespace MoneyTransferAPI.Tests.Handlers.Command.User
{
    public class CreateUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CreateUserCommandHandler _handler;

        public CreateUserCommandHandlerTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new CreateUserCommandHandler(_mockUserRepository.Object, _mockMapper.Object);
        }

        [Fact]

        public async Task Handle_GivenValidModel_ShouldCreateUser()
        {
            var createUserCommand = new CreateUserCommand
            {
                Email = "test@test.com",
                Currency = "USD",
                FirstName = "Test",
                LastName = "Test",
                Password = "TestPassword123!"
            };

            _mockUserRepository.Setup(repo => repo.AddAsync(It.IsAny<Core.Entities.User>()))
                               .Returns(Task.CompletedTask);

            _mockMapper.Setup(mapper => mapper.Map<UserDto>(It.IsAny<Core.Entities.User>()))
                        .Returns(new UserDto { FirstName = createUserCommand.FirstName, LastName = createUserCommand.LastName });

            var result = await _handler.Handle(createUserCommand, new CancellationToken());

            Assert.NotNull(result);
            _mockUserRepository.Verify(repo => repo.AddAsync(It.IsAny<Core.Entities.User>()), Times.Once);
        }

    }
}

