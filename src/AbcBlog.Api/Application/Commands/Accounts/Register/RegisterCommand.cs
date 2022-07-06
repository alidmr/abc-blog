using MediatR;

namespace AbcBlog.Api.Application.Commands.Accounts.Register
{
    public class RegisterCommand : IRequest<RegisterCommandResult>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
    }
}
