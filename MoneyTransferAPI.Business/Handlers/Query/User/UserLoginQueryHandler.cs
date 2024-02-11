using AutoMapper;
using MediatR;
using MoneyTransferAPI.Core.DTOs.User.Response;
using MoneyTransferAPI.Core.Generals;
using MoneyTransferAPI.Core.Queries.User;
using MoneyTransferAPI.Infrastructure.Authentication;
using MoneyTransferAPI.Interface.Repositories;
using static MoneyTransferAPI.Infrastructure.Authentication.JWTAuthenticationManager;

namespace MoneyTransferAPI.Business.Handlers.Query.User
{
    public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, Response<LoginResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly JWTAuthenticationManager _jwtAuthManager;

        public UserLoginQueryHandler(IUserRepository userRepository, IMapper mapper, JWTAuthenticationManager jwtAuthManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtAuthManager = jwtAuthManager;
        }

        public async Task<Response<LoginResponse>> Handle(UserLoginQuery query, CancellationToken cancellationToken)
        {
            //TODO
            Response<LoginResponse> response = new();
            var user = await _userRepository.GetAsync(u => u.Email == query.Email && u.Status);

            if (user == null || !HashingHelper.VerifyPasswordHash(query.Password, user.PasswordSalt, user.PasswordHash))
            {
                return response = Response<LoginResponse>.Fail("User not found or passsword incorrect");
            }

            var token = _jwtAuthManager.Authenticate($"{user.FirstName} {user.LastName}");

            response = Response<LoginResponse>.Success(new LoginResponse
            {
                Token = token
            });

            return response;
        }
    }


}
