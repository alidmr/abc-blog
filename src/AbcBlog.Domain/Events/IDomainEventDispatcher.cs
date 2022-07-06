namespace AbcBlog.Domain.Events
{
    public interface IDomainEventDispatcher : IDisposable
    {
        Task Dispatch(IEvent @event);
    }
}
