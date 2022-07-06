namespace AbcBlog.Api.Application.Commands.Users.Create.Dtos
{
    public class CreateUserDto
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
    }
}
