using AbcBlog.Api.Application.Constants;
using AbcBlog.Api.Application.Queries.Articles.GetArticleById.Dtos;
using AbcBlog.Domain.Interfaces.Articles;
using AbcBlog.Shared.Exceptions;
using MediatR;

namespace AbcBlog.Api.Application.Queries.Articles.GetArticleById
{
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, GetArticleByIdQueryResult>
    {
        private readonly IArticleRepository _articleRepository;

        public GetArticleByIdQueryHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<GetArticleByIdQueryResult> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetByIdAsync(request.Id);
            if (article == null)
                throw new BusinessException(nameof(ApplicationErrorCode.Error14), ApplicationErrorCode.Error14);

            var result = new GetArticleByIdQueryResult()
            {
                Result = new GetArticleByIdDto()
                {
                    Id = article.Id,
                    Status = article.Status.Name,
                    CreatedDate = article.CreatedDate,
                    Description = article.Description,
                    OwnerId = article.OwnerId,
                    StatusId = article.Status.Id,
                    Title = article.Title
                }
            };

            return result;
        }
    }
}
