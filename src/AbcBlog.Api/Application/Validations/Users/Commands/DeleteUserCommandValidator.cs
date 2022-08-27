using AbcBlog.Api.Application.Commands.Users.Delete;
using AbcBlog.Api.Application.Constants;
using FluentValidation;

namespace AbcBlog.Api.Application.Validations.Users.Commands
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithErrorCode(nameof(ApplicationErrorCode.Error7))
                .WithMessage(ApplicationErrorCode.Error7);
        }
    }
}
