using MediatR;

namespace AbcBlog.Api.Application.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<GetUsersQueryResult>
    {
        public GetUsersQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; private set; }
        public int PageSize { get; private set; }

    }
}
