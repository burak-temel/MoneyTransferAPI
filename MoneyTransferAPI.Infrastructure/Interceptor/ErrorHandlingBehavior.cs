using MediatR;
using Microsoft.Extensions.Logging;
using MoneyTransferAPI.Infrastructure.Logging;

namespace MoneyTransferAPI.Infrastructure.Interceptor
{
    public class ErrorHandlingBehavior<TRequest, TResponse> : MethodInterceptionBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<FileLogger> _logger;

        public ErrorHandlingBehavior(ILogger<FileLogger> logger)
        {
            _logger = logger;
        }

        protected override void OnException(TRequest request, Exception exception)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogError(exception.Message, "Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);//TODO : Kontrol edilecek   
        }
    }


}
    