using MediatR;

namespace AbcBlog.Domain.Events
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;

        public DomainEventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Dispatch(IEvent @event)
        {
            var eventItem = new NotificationEnvelope(@event);
            await _mediator.Publish(eventItem);
        }

        public void Dispose()
        {
        }
    }
}
