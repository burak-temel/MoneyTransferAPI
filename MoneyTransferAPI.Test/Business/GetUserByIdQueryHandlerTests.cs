using Moq;
using MoneyTransferAPI.RepositoryInterface;
using AutoMapper;
using MoneyTransferAPI.Business.Handlers.Query.User;
using MoneyTransferAPI.Core.Queries.User;
using MoneyTransferAPI.Core.DTOs.User;

namespace MoneyTransferAPI.Tests.Handlers
{
    public class GetUserByIdQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly GetUserByIdQueryHandler _handler;

        public GetUserByIdQueryHandlerTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new GetUserByIdQueryHandler(_mockUserRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Handle_UserExists_ShouldReturnUser()
        {
            var query = new GetUserByIdQuery { UserId = new Guid() };
            var user = new Core.Entities.User {Id = query.UserId , FirstName = "Burak", LastName = "MoneyTransferAPI.Core.Entities.User", Email = "burak@burak.com", Status = true };

            _mockUserRepository.Setup(repo => repo.GetByIdAsync(query.UserId))
                               .ReturnsAsync(user);

            _mockMapper.Setup(mapper => mapper.Map<UserDto>(It.IsAny<Core.Entities.User>()))
                       .Returns(new UserDto { FirstName = user.FirstName, LastName = user.LastName });

            var result = await _handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal(user.FirstName, result.FirstName);
            Assert.Equal(user.LastName, result.LastName);
        }

        [Fact]
        public async Task Handle_UserDoesNotExist_ShouldReturnNull()
        {
            var query = new GetUserByIdQuery { UserId = Guid.NewGuid() };

            _mockUserRepository.Setup(repo => repo.GetByIdAsync(query.UserId))
                               .ReturnsAsync((Core.Entities.User)null);

            var result = await _handler.Handle(query, CancellationToken.None);

            Assert.Null(result);
        }
    }
}
