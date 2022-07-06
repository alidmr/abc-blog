using AbcBlog.Api.Application.Queries.GetUsers.Dtos;

namespace AbcBlog.Api.Application.Queries.GetUsers
{
    public class GetUsersQueryResult : BaseQueryResult
    {
        public List<GetUsersDto> Result { get; set; }
    }
}
