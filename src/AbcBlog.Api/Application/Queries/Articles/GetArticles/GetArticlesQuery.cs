using MediatR;

namespace AbcBlog.Api.Application.Queries.Articles.GetArticles
{
    public class GetArticlesQuery : IRequest<GetArticlesQueryResult>
    {
        public GetArticlesQuery(int page, int pageSize, string? searchKey)
        {
            Page = page;
            PageSize = pageSize;
            SearchKey = searchKey;
        }

        public int Page { get; private set; }
        public int PageSize { get; private set; }
        public string? SearchKey { get; private set; }
    }
}
