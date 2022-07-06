namespace AbcBlog.Domain.Events.Users
{
    public class UserDeletedEvent : BaseDomainEvent
    {
        public UserDeletedEvent(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
    }
}
