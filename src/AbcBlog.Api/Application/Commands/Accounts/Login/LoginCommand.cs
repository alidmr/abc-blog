using MediatR;

namespace AbcBlog.Api.Application.Commands.Accounts.Login
{
    public class LoginCommand : IRequest<LoginCommandResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
