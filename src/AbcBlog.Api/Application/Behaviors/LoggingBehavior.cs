using MediatR;

namespace AbcBlog.Api.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation($"### Handling command. Request : {request}, Date : {DateTime.Now} ###");

            var response = await next();

            _logger.LogInformation($"### Command handled. Date : {DateTime.Now}");

            return response;
        }
    }
}
