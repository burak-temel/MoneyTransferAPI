using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MoneyTransferAPI.Infrastructure.Authentication;
using MoneyTransferAPI.Infrastructure.Logging;
using System;
using Microsoft.OpenApi.Models;
using MoneyTransferAPI.Infrastructure.AutoMapper;

namespace MoneyTransferAPI.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Money Transfer API", Version = "v1" });
            });

            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddJwtAuthentication(configuration);

            services.AddLoggingServices(configuration);

            services.AddAutoMapperServices(configuration);

            return services;
        }   
    }

}
