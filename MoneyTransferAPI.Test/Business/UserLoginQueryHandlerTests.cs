using Xunit;
using Moq;
using MoneyTransferAPI.Core.Queries.User;
using MoneyTransferAPI.Business.Handlers.Query.User;
using MoneyTransferAPI.Infrastructure.Authentication;
using MoneyTransferAPI.RepositoryInterface;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MoneyTransferAPI.Tests.Handlers.Command.User
{
    public class UserLoginQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<JWTAuthenticationManager> _mockJwtAuthManager;
        private readonly UserLoginQueryHandler _handler;

        public UserLoginQueryHandlerTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockMapper = new Mock<IMapper>();

            var inMemorySettings = new Dictionary<string, string>
                    {
                        {"JWT:Secret", "YourSuperSecretKeyForTesting"}
                    };

            IConfiguration mockConfiguration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
            _mockJwtAuthManager = new Mock<JWTAuthenticationManager>(mockConfiguration);
            _handler = new UserLoginQueryHandler(
            _mockUserRepository.Object,
            _mockMapper.Object,
            _mockJwtAuthManager.Object);
        }

        [Fact]
        public async Task Handle_GivenValidCredentials_ShouldReturnValidToken()
        {
            var query = new UserLoginQuery
            {
                Email = "test@example.com",
                Password = "TestPassword123!",
            };

            // Simulate user with matching password hash

            HashingHelper.CreatePasswordHash("TestPassword123!", out byte[] passwordHash, out byte[] passwordSalt);

            var user = new Core.Entities.User
            {
                FirstName = "Test",
                LastName = "Test",
                Email = query.Email,
                Status = true,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _mockUserRepository.Setup(repo => repo.GetAsync(u => u.Email == query.Email && u.Status))
                               .ReturnsAsync(user);

            _mockJwtAuthManager.Setup(jwt => jwt.Authenticate($"{user.FirstName} {user.LastName}"))
                               .Returns("ValidTokenString");

            var result = await _handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.True(result.Result);
            Assert.Equal("ValidTokenString", result.Data.Token);
            _mockJwtAuthManager.Verify(jwt => jwt.Authenticate(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task Handle_GivenInvalidCredentials_ShouldReturnFailure()
        {
            var query = new UserLoginQuery
            {
                Email = "invalid@example.com",
                Password = "InvalidPassword123!"
            };

            // Simulate user retrieval from repository

            HashingHelper.CreatePasswordHash("TestPassword123!", out byte[] passwordHash, out byte[] passwordSalt);

            var user = new Core.Entities.User
            {
                Email = "test@example.com",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _mockUserRepository.Setup(repo => repo.GetAsync(u => u.Email == user.Email))
                               .ReturnsAsync(user);

            var result = await _handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.False(result.Result);
            Assert.Null(result.Data);
            _mockJwtAuthManager.Verify(jwt => jwt.Authenticate(It.IsAny<string>()), Times.Never);
        }

        // Additional test methods as necessary...
    }
}
