using AbcBlog.Api.Application.Commands.Users.Create;
using AbcBlog.Api.Application.Constants;
using FluentValidation;

namespace AbcBlog.Api.Application.Validations.Users
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error1)).WithMessage(ApplicationErrorCode.Error1);
            RuleFor(x => x.LastName).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error2)).WithMessage(ApplicationErrorCode.Error2);
            RuleFor(x => x.Email).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error3)).WithMessage(ApplicationErrorCode.Error3);
            RuleFor(x => x.Password).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error4)).WithMessage(ApplicationErrorCode.Error4);
        }
    }
}
