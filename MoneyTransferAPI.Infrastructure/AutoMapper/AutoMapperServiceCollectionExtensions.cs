using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MoneyTransferAPI.Infrastructure.AutoMapper
{
    public static class AutoMapperServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
