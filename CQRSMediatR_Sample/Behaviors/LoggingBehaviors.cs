using MediatR;

namespace CQRSMediatR_Sample.Behaviors
{
    public class LoggingBehaviors<TRequest,TResponse>:IPipelineBehavior<TRequest,TResponse> where TRequest: IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehaviors<TRequest, TResponse>> _logger;
        public LoggingBehaviors(ILogger<LoggingBehaviors<TRequest,TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request,RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");
            var response = await next();
            _logger.LogInformation($"Handled {typeof(TResponse).Name}");
            return response;
        }
    }
}
