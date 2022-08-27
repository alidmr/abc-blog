using AbcBlog.Api.Application.Constants;
using AbcBlog.Api.Application.Queries.Users.GetUsers;
using FluentValidation;

namespace AbcBlog.Api.Application.Validations.Users.Queries
{
    public class GetUsersQueryValidator : AbstractValidator<GetUsersQuery>
    {
        public GetUsersQueryValidator()
        {
            RuleFor(x => x.Page).GreaterThan(0)
                .WithErrorCode(nameof(ApplicationErrorCode.Error21)).WithMessage(ApplicationErrorCode.Error21);

            RuleFor(x => x.PageSize).GreaterThan(0)
                .WithErrorCode(nameof(ApplicationErrorCode.Error22)).WithMessage(ApplicationErrorCode.Error22);
        }
    }
}
