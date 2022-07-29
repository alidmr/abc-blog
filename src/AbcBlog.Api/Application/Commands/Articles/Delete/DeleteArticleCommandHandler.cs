using AbcBlog.Api.Application.Constants;
using AbcBlog.Domain.Aggregates.Articles;
using AbcBlog.Domain.Interfaces.Articles;
using AbcBlog.Shared.Exceptions;
using MediatR;

namespace AbcBlog.Api.Application.Commands.Articles.Delete
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, DeleteArticleCommandResult>
    {
        private readonly IArticleRepository _articleRepository;

        public DeleteArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<DeleteArticleCommandResult> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetByIdAsync(request.Id);

            if (article == null)
                throw new BusinessException(nameof(ApplicationErrorCode.Error14), ApplicationErrorCode.Error14);

            if (article.Status == ArticleStatus.Deleted)
                throw new BusinessException(nameof(ApplicationErrorCode.Error20), ApplicationErrorCode.Error20);

            article.Delete();

            await _articleRepository.UpdateAsync(article);

            var result = await _articleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteArticleCommandResult()
            {
                Message = "İşlem başarılı",
                Result = result > 0
            };
        }
    }
}
