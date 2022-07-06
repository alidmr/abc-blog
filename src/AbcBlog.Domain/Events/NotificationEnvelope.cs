using MediatR;

namespace AbcBlog.Domain.Events
{
    public class NotificationEnvelope : INotification
    {
        public NotificationEnvelope(IEvent @event)
        {
            Event = @event;
        }

        public IEvent Event { get; }
    }
}
