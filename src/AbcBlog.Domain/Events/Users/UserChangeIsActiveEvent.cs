namespace AbcBlog.Domain.Events.Users
{
    public class UserChangeIsActiveEvent : BaseDomainEvent
    {
        public UserChangeIsActiveEvent(Guid userId, bool isActive)
        {
            UserId = userId;
            IsActive = isActive;
        }

        public bool IsActive { get; private set; }
        public Guid UserId { get; private set; }
    }
}

