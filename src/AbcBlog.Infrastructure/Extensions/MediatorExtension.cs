using AbcBlog.Domain.SeedWorks;
using AbcBlog.Infrastructure.Context;
using MediatR;

namespace AbcBlog.Infrastructure.Extensions
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, AbcBlogContext context)
        {
            var domainEntities = context.ChangeTracker.Entries<BaseEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities.SelectMany(x => x.Entity.DomainEvents).ToList();

            var domainEntityList = domainEntities.ToList();

            foreach (var entity in domainEntityList)
            {
                entity.Entity.ClearDomainEvent();
            }

            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);
            }
        }
    }
}
