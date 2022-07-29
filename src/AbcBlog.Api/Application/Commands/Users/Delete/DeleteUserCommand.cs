using MediatR;

namespace AbcBlog.Api.Application.Commands.Users.Delete
{
    public class DeleteUserCommand : IRequest<DeleteUserCommandResult>
    {
        public DeleteUserCommand(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; private set; }
    }
}
