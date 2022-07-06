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

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
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
                // todo : logging

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
