using AbcBlog.Domain.Events.Users;
using MediatR;

namespace AbcBlog.Domain.EventHandlers.Users
{
    public class UserEmailVerificationEventHandler : INotificationHandler<UserEmailVerificationEvent>
    {
        public async Task Handle(UserEmailVerificationEvent notification, CancellationToken cancellationToken)
        {
            // send verification email
            await Task.CompletedTask;
        }
    }
}
