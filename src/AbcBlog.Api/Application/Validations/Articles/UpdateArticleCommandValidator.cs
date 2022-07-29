using AbcBlog.Api.Application.Commands.Articles.Update;
using AbcBlog.Api.Application.Constants;
using FluentValidation;

namespace AbcBlog.Api.Application.Validations.Articles
{
    public class UpdateArticleCommandValidator : AbstractValidator<UpdateArticleCommand>
    {
        public UpdateArticleCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error19)).WithMessage(ApplicationErrorCode.Error19);

            RuleFor(x => x.Id).GreaterThan(0)
                .WithErrorCode(nameof(ApplicationErrorCode.Error19)).WithMessage(ApplicationErrorCode.Error19);

            RuleFor(x => x.Title).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error16)).WithMessage(ApplicationErrorCode.Error16);

            RuleFor(x => x.Description).NotEmpty()
                .WithErrorCode(nameof(ApplicationErrorCode.Error17)).WithMessage(ApplicationErrorCode.Error17);
        }
    }
}
