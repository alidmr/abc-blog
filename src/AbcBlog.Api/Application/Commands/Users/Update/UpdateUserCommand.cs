using MediatR;

namespace AbcBlog.Api.Application.Commands.Users.Update
{
    public class UpdateUserCommand : IRequest<UpdateUserCommandResult>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
