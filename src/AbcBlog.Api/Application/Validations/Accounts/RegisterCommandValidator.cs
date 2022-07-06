using AbcBlog.Api.Application.Commands.Accounts.Register;
using AbcBlog.Api.Application.Constants;
using FluentValidation;

namespace AbcBlog.Api.Application.Validations.Accounts
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error1)).WithMessage(ApplicationErrorCode.Error1);

            RuleFor(x => x.LastName).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error2)).WithMessage(ApplicationErrorCode.Error2);

            RuleFor(x => x.Email).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error3)).WithMessage(ApplicationErrorCode.Error3);

            RuleFor(x => x.Password).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error4)).WithMessage(ApplicationErrorCode.Error4)
                .MinimumLength(6).WithErrorCode(nameof(ApplicationErrorCode.Error12)).WithMessage(ApplicationErrorCode.Error12);

            RuleFor(x => x.RePassword).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error10)).WithMessage(ApplicationErrorCode.Error10);

            RuleFor(x => x).Custom((x, y) =>
            {
                if (!string.IsNullOrEmpty(x.Password) && !string.IsNullOrEmpty(x.RePassword))
                {
                    if (!x.Password.Equals(x.RePassword))
                    {
                        y.AddFailure(nameof(x.RePassword), ApplicationErrorCode.Error11);
                    }
                }
            });
        }
    }
}
