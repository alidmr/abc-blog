using AbcBlog.Api.Application.Constants;
using AbcBlog.Domain.Interfaces.Articles;
using AbcBlog.Shared.Exceptions;
using MediatR;

namespace AbcBlog.Api.Application.Commands.Articles.Update
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, UpdateArticleCommandResult>
    {
        private readonly IArticleRepository _articleRepository;

        public UpdateArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<UpdateArticleCommandResult> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetByIdAsync(request.Id);
            if (article == null)
                throw new BusinessException(nameof(ApplicationErrorCode.Error14), ApplicationErrorCode.Error14);

            var oldTitle = article.Title;

            article.Update(request.Title, request.Description);

            if (!oldTitle.Equals(request.Title))
                article.SetSlug();

            await _articleRepository.UpdateAsync(article);

            var result = await _articleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return new UpdateArticleCommandResult()
            {
                Message = "İşlem başarılı",
                Result = result > 0
            };
        }
    }
}
