using AbcBlog.Api.Application.Queries.Articles.GetArticles.Dtos;
using AbcBlog.Domain.Interfaces.Articles;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AbcBlog.Api.Application.Queries.Articles.GetArticles
{
    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, GetArticlesQueryResult>
    {
        private readonly IArticleRepository _articleRepository;

        public GetArticlesQueryHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<GetArticlesQueryResult> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            var query = _articleRepository.Table;

            if (!string.IsNullOrEmpty(request.SearchKey))
                query = query.Where(x => x.Title.Contains(request.SearchKey));

            query = query.OrderByDescending(x => x.CreatedDate);

            var articles = await query.Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize).ToListAsync(cancellationToken);

            var result = new GetArticlesQueryResult()
            {
                Result = articles.Select(x => new GetArticlesDto()
                {
                    Id = x.Id,
                    CreatedDate = x.CreatedDate,
                    Title = x.Title,
                    Description = x.Description,
                    StatusId = x.Status.Id,
                    Status = x.Status.Name,
                    OwnerId = x.OwnerId,

                }).ToList()
            };

            return result;
        }
    }
}
