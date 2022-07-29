using AbcBlog.Api.Application.Commands.Users.ChangeEmail;
using AbcBlog.Api.Application.Constants;
using FluentValidation;

namespace AbcBlog.Api.Application.Validations.Users
{
    public class ChangeUserEmailCommandValidator : AbstractValidator<ChangeUserEmailCommand>
    {
        public ChangeUserEmailCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error7)).WithMessage(ApplicationErrorCode.Error7);

            RuleFor(x => x.Id).Custom((x, y) =>
            {
                if (x <= 0)
                {
                    y.AddFailure("Id", ApplicationErrorCode.Error7);
                }
            });

            RuleFor(x => x.Email).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error3)).WithMessage(ApplicationErrorCode.Error3);
        }
    }
}
