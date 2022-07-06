using AbcBlog.Api.Application.Commands.Accounts.Login.Dtos;

namespace AbcBlog.Api.Application.Commands.Accounts.Login
{
    public class LoginCommandResult : BaseCommandResult
    {
        public LoginResponseDto Result { get; set; }
    }
}
