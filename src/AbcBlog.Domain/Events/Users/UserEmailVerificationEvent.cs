namespace AbcBlog.Domain.Events.Users
{
    public class UserEmailVerificationEvent : BaseDomainEvent
    {
        public UserEmailVerificationEvent(string fullName, Guid userId)
        {
            FullName = fullName;
            UserId = userId;
        }

        public string FullName { get; private set; }
        public Guid UserId { get; private set; }
    }
}
