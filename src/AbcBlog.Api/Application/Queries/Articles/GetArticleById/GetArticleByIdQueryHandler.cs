using AbcBlog.Api.Application.Constants;
using AbcBlog.Api.Application.Queries.Articles.GetArticleById.Dtos;
using AbcBlog.Domain.Interfaces.Articles;
using AbcBlog.Domain.Interfaces.Users;
using AbcBlog.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AbcBlog.Api.Application.Queries.Articles.GetArticleById
{
    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, GetArticleByIdQueryResult>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUserRepository _userRepository;

        public GetArticleByIdQueryHandler(IArticleRepository articleRepository, IUserRepository userRepository)
        {
            _articleRepository = articleRepository;
            _userRepository = userRepository;
        }

        public async Task<GetArticleByIdQueryResult> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var articleQuery = _articleRepository.Table;
            var userQuery = _userRepository.Table;

            var article = await (from a in articleQuery
                                 join u in userQuery on a.CreatedUserId equals u.Id
                                 where a.Id == request.Id
                                 select new GetArticleByIdDto()
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
                                 }).FirstOrDefaultAsync(cancellationToken);

            if (article == null)
                throw new BusinessException(nameof(ApplicationErrorCode.Error14), ApplicationErrorCode.Error14);

            var result = new GetArticleByIdQueryResult()
            {
                Result = article
            };

            return result;
        }
    }
}
