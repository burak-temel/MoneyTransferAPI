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
            string logFilePath = configuration["FileLogging:Path"] ?? "logs.txt";
            services.AddSingleton<ILoggerProvider>(provider => new FileLoggerProvider(logFilePath));

            return services;
        }
    }
}
