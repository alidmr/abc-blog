using AbcBlog.Api.Application.Queries.Users.GetUserById.Dtos;

namespace AbcBlog.Api.Application.Queries.Users.GetUserById
{
    public class GetUserByIdQueryResult : BaseQueryResult
    {
        public GetUserByIdDto? Result { get; set; }
    }
}
