using AbcBlog.Api.Application.Constants;
using AbcBlog.Api.Application.Queries.Users.GetUserById;
using FluentValidation;

namespace AbcBlog.Api.Application.Validations.Users.Queries
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0)
                .WithErrorCode(ApplicationErrorCode.Error7).WithMessage(ApplicationErrorCode.Error7);
        }
    }
}
