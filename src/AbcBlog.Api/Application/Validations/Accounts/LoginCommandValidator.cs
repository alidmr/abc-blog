using AbcBlog.Api.Application.Commands.Accounts.Login;
using AbcBlog.Api.Application.Constants;
using FluentValidation;

namespace AbcBlog.Api.Application.Validations.Accounts
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error3)).WithMessage(ApplicationErrorCode.Error3);

            RuleFor(x => x.Password).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error4)).WithMessage(ApplicationErrorCode.Error4);
        }
    }
}
