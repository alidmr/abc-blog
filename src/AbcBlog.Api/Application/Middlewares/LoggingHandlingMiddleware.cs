using Microsoft.AspNetCore.Http.Extensions;

namespace AbcBlog.Api.Application.Middlewares
{
    public class LoggingHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<LoggingHandlingMiddleware> _logger;

        public LoggingHandlingMiddleware(ILogger<LoggingHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation($"Start to [Host: {context.Request.Host}, Path: {context.Request.Path}, Method: {context.Request.Method}, DisplayUrl: {context.Request.GetDisplayUrl()}] request");

            await next(context);

            _logger.LogInformation($"Request completed with status code: {context.Response.StatusCode} ");
        }
    }
}
