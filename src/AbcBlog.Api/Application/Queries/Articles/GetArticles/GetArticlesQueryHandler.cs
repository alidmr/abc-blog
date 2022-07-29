using AbcBlog.Api.Application.Queries.Articles.GetArticles.Dtos;
using AbcBlog.Domain.Interfaces.Articles;
using AbcBlog.Domain.Interfaces.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AbcBlog.Api.Application.Queries.Articles.GetArticles
{
    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, GetArticlesQueryResult>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUserRepository _userRepository;

        public GetArticlesQueryHandler(IArticleRepository articleRepository, IUserRepository userRepository)
        {
            _articleRepository = articleRepository;
            _userRepository = userRepository;
        }

        public async Task<GetArticlesQueryResult> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            var articleQuery = _articleRepository.Table;
            var userQuery = _userRepository.Table;

            var resultQuery = (from a in articleQuery
                               join u in userQuery on a.CreatedUserId equals u.Id
                               select new GetArticlesDto()
                               {
                                   Id = a.Id,
                                   CreatedUserId = a.CreatedUserId,
                                   Status = a.Status.Name,
                                   CreatedDate = a.CreatedDate,
                                   Description = a.Description,
                                   CreatedUserName = $"{u.FirstName} {u.LastName}",
                                   StatusId = a.Status.Id,
                                   Title = a.Title,
                                   Slug = a.Slug
                               }).OrderByDescending(x => x.CreatedDate);

            if (!string.IsNullOrEmpty(request.SearchKey))
                resultQuery = (IOrderedQueryable<GetArticlesDto>)resultQuery.Where(x => x.Title.Contains(request.SearchKey));

            var articles = await resultQuery.Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize).ToListAsync(cancellationToken);

            return new GetArticlesQueryResult()
            {
                Result = articles
            };
        }
    }
}
