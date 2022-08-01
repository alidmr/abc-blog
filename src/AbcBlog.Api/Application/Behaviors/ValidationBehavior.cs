using AbcBlog.Shared.Dtos;
using AbcBlog.Shared.Enums;
using FluentValidation;
using MediatR;
using ValidationException = AbcBlog.Shared.Exceptions.ValidationException;

namespace AbcBlog.Api.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, ILogger<ValidationBehavior<TRequest, TResponse>> logger)
        {
            _validators = validators;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var errors = _validators
                .Select(x => x.Validate(request))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .ToList();

            if (errors.Any())
            {
                _logger.LogError($"[VALIDATION ERROR] Request : {request}");

                var errorList = new List<ErrorDto>();
                foreach (var error in errors)
                {
                    errorList.Add(new ErrorDto()
                    {
                        Id = Guid.NewGuid(),
                        Code = error.ErrorCode,
                        Type = ErrorType.Error,
                        Content = error.ErrorMessage
                    });
                }

                throw new ValidationException(errorList);
            }

            return await next();
        }
    }
}
