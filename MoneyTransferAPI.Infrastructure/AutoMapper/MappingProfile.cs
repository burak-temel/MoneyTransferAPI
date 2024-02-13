using AutoMapper;
using Microsoft.Extensions.Logging;
using MoneyTransferAPI.Core.DTOs.Transaction;
using MoneyTransferAPI.Core.DTOs.User;
using MoneyTransferAPI.Core.Entities;
using System.Security.AccessControl;

namespace MoneyTransferAPI.Infrastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Transaction, TransactionDto>();
        }
    }
}
