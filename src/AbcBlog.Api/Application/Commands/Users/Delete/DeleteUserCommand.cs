using MediatR;

namespace AbcBlog.Api.Application.Commands.Users.Delete
{
    public class DeleteUserCommand : IRequest<DeleteUserCommandResult>
    {
        public DeleteUserCommand(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
    }
}
