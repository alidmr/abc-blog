using AbcBlog.Domain.ValueObjects;

namespace AbcBlog.Api.Application.Commands.Accounts.Login.Dtos
{
    public class LoginResponseDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public AccessToken AccessToken { get; set; }
    }
}
