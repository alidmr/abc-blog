using MediatR;

namespace AbcBlog.Api.Application.Queries.Articles.GetArticleById
{
    public class GetArticleByIdQuery : IRequest<GetArticleByIdQueryResult>
    {
        public GetArticleByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
