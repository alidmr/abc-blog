using AbcBlog.Api.Application.Queries.Articles.GetArticleById.Dtos;

namespace AbcBlog.Api.Application.Queries.Articles.GetArticleById
{
    public class GetArticleByIdQueryResult : BaseQueryResult
    {
        public GetArticleByIdDto Result { get; set; }
    }
}
