using AbcBlog.Domain.Events;

namespace AbcBlog.Domain.SeedWorks
{
    public class BaseEntity
    {
        private List<IEvent> _domainEvents;
        public IReadOnlyCollection<IEvent> DomainEvents =>
            _domainEvents == null ? new List<IEvent>().AsReadOnly() : _domainEvents.AsReadOnly();

        public List<IEvent> GetDomainEvents()
        {
            return _domainEvents;
        }
        public void AddDomainEvent(IEvent @event)
        {
            _domainEvents = _domainEvents ?? new List<IEvent>();
            _domainEvents.Add(@event);
        }

        public void RemoveDomainEvent(IEvent @event)
        {
            if (_domainEvents.Find(x => x == @event) != null)
                _domainEvents.Remove(@event);
        }

        public void ClearDomainEvent()
        {
            _domainEvents.Clear();
        }

    }

    public class BaseEntity<TId> : BaseEntity
    {
        public TId Id { get; set; }
    }
}
