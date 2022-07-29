using MediatR;

namespace AbcBlog.Api.Application.Commands.Users.ChangeEmail
{
    public class ChangeUserEmailCommand : IRequest<ChangeUserEmailCommandResult>
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
