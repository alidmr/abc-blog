using AbcBlog.Api.Application.Commands.Users.Create.Dtos;

namespace AbcBlog.Api.Application.Commands.Users.Create
{
    public class CreateUserCommandResult : BaseCommandResult
    {
        public CreateUserDto? Result { get; set; }
    }
}
