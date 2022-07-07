using AbcBlog.Api.Application.Queries.Articles.GetArticles.Dtos;

namespace AbcBlog.Api.Application.Queries.Articles.GetArticles
{
    public class GetArticlesQueryResult : BaseQueryResult
    {
        public List<GetArticlesDto> Result { get; set; }
    }
}
