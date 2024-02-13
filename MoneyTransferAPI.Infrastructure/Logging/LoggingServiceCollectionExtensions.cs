using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MoneyTransferAPI.Interface;

namespace MoneyTransferAPI.Infrastructure.Logging
{
    public static class LoggingServiceCollectionExtensions
    {
        public static IServiceCollection AddLoggingServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddLogging(builder =>
            {
                builder.ClearProviders(); // Clear existing providers
                string logFilePath = configuration["FileLogging:Path"] ?? "logs.txt";
                builder.AddProvider(new FileLoggerProvider(logFilePath));
            });

            return services;
        }
    }
}
