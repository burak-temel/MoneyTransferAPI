using MediatR;

namespace MoneyTransferAPI.Infrastructure.Interceptor
{
    public class MethodInterceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        protected virtual void OnBefore(TRequest request) { }
        protected virtual void OnAfter(TRequest request, TResponse? response) { }
        protected virtual void OnException(TRequest request, Exception exception) { }
        protected virtual void OnSuccess(TRequest request, TResponse response) { }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            TResponse response = default;

            OnBefore(request);

            try
            {
                response = await next();
                OnSuccess(request, response);
            }
            catch (Exception e)
            {
                OnException(request, e);
                throw; 
            }
            finally
            {
                OnAfter(request, response);
            }

            return response;
        }
    }
}
