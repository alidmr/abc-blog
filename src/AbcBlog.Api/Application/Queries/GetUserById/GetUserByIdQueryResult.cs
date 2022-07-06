using AbcBlog.Api.Application.Queries.GetUserById.Dtos;

namespace AbcBlog.Api.Application.Queries.GetUserById
{
    public class GetUserByIdQueryResult : BaseQueryResult
    {
        public GetUserByIdDto? Result { get; set; }
    }
}
