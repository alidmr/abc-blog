using AbcBlog.Api.Application.Commands.Articles.Create;
using AbcBlog.Api.Application.Constants;
using FluentValidation;

namespace AbcBlog.Api.Application.Validations.Articles
{
    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        public CreateArticleCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error16)).WithMessage(ApplicationErrorCode.Error16);

            RuleFor(x => x.Description).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error17)).WithMessage(ApplicationErrorCode.Error17);

            RuleFor(x => x.CreatedUserId).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error18)).WithMessage(ApplicationErrorCode.Error18);

            RuleFor(x => x.CreatedUserId).Custom((x, y) =>
            {
                if (x <= 0)
                {
                    y.AddFailure("CreatedUserId", ApplicationErrorCode.Error18);
                }
            });
        }
    }

}
