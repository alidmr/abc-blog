using MediatR;

namespace AbcBlog.Api.Application.Queries.Articles.GetArticleById
{
    public class GetArticleByIdQuery : IRequest<GetArticleByIdQueryResult>
    {
        public GetArticleByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
