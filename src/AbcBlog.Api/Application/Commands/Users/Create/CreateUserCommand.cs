using MediatR;

namespace AbcBlog.Api.Application.Commands.Users.Create
{
    public class CreateUserCommand : IRequest<CreateUserCommandResult>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}