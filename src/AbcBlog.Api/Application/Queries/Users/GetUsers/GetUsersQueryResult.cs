using AbcBlog.Api.Application.Queries.Users.GetUsers.Dtos;

namespace AbcBlog.Api.Application.Queries.Users.GetUsers
{
    public class GetUsersQueryResult : BaseQueryResult
    {
        public List<GetUsersDto> Result { get; set; }
    }
}
