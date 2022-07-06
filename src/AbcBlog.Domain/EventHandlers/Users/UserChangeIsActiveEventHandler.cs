using AbcBlog.Domain.Events.Users;
using MediatR;

namespace AbcBlog.Domain.EventHandlers.Users
{
    public class UserChangeIsActiveEventHandler : INotificationHandler<UserChangeIsActiveEvent>
    {
        public async Task Handle(UserChangeIsActiveEvent notification, CancellationToken cancellationToken)
        {
            // user db update operations

            await Task.CompletedTask;
        }
    }
}
