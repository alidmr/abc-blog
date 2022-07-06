using MediatR;

namespace AbcBlog.Domain.Events
{
    public class BaseDomainEvent : IEvent, INotification
    {
        public BaseDomainEvent()
        {
            EventId = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }

        public Guid EventId { get; }
        public DateTime CreatedDate { get; }
    }
}
