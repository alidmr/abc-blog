using MediatR;

namespace AbcBlog.Api.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdQueryResult>
    {
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
