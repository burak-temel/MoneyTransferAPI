using AutoMapper;
using MediatR;
using MoneyTransferAPI.Core.DTOs.User;
using MoneyTransferAPI.Core.Queries.User;
using MoneyTransferAPI.Interface.Repositories;

namespace MoneyTransferAPI.Business.Handlers.Query.User
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(query.UserId);
            return _mapper.Map<UserDto>(user);
        }
    }

}
