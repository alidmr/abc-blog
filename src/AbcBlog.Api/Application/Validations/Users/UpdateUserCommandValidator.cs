using AbcBlog.Api.Application.Commands.Users.Update;
using AbcBlog.Api.Application.Constants;
using FluentValidation;

namespace AbcBlog.Api.Application.Validations.Users
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error7)).WithMessage(ApplicationErrorCode.Error7);

            RuleFor(x => x.FirstName).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error1)).WithMessage(ApplicationErrorCode.Error1);

            RuleFor(x => x.LastName).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error2)).WithMessage(ApplicationErrorCode.Error2);
        }
    }
}
