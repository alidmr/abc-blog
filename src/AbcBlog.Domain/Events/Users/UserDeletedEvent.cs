namespace AbcBlog.Domain.Events.Users
{
    public class UserDeletedEvent : BaseDomainEvent
    {
        public UserDeletedEvent(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; private set; }
    }
}
