using System.Net;
using System.Security.Authentication;
using AbcBlog.Domain.Exceptions;
using AbcBlog.Shared.Dtos;
using AbcBlog.Shared.Enums;
using AbcBlog.Shared.Exceptions;
using AbcBlog.Shared.Response;
using Newtonsoft.Json;
using ValidationException = AbcBlog.Shared.Exceptions.ValidationException;

namespace AbcBlog.Api.Application.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private const string ErrorMessage = "Üzgünüz! İşleminiz sırasında beklenmedik bir hata olustu.";

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string errorCode;
            HttpStatusCode statusCode;
            string message = exception.Message;

            var response = new ErrorResponse();

            switch (exception)
            {
                case ValidationException validationException:
                    {
                        errorCode = "ErrorValidationException";
                        statusCode = HttpStatusCode.BadRequest;
                        response.Errors = validationException.Errors;
                        break;
                    }
                case DomainException domainException:
                    {
                        errorCode = domainException.Code;
                        switch (errorCode)
                        {
                            default:
                                statusCode = HttpStatusCode.BadRequest;
                                message = domainException.Message;
                                break;
                        }
                        break;
                    }
                case BusinessException businessException:
                    {
                        errorCode = businessException.Code;
                        switch (errorCode)
                        {
                            default:
                                statusCode = HttpStatusCode.BadRequest;
                                message = businessException.Message;
                                break;
                        }
                        break;
                    }
                case AuthenticationException authenticationException:
                    {
                        errorCode = "ErrorAuthenticationException";
                        statusCode = HttpStatusCode.Unauthorized;
                        break;
                    }
                default:
                    errorCode = "ErrorInternalServer";
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            if (statusCode == HttpStatusCode.InternalServerError)
            {
                message = exception.Message;
            }

            if (exception is not ValidationException)
            {
                response.Errors = new List<ErrorDto>()
                {
                    new()
                    {
                        Code = errorCode,
                        Id = Guid.NewGuid(),
                        Type = ErrorType.Error,
                        Content = message
                    }
                };
            }

            _logger.LogError("[ERROR] Code : {errorCode} StatusCode : {statusCode} Message : {message}", errorCode, statusCode, message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
