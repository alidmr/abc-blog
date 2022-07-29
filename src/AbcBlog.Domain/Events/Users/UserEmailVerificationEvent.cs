namespace AbcBlog.Domain.Events.Users
{
    public class UserEmailVerificationEvent : BaseDomainEvent
    {
        public UserEmailVerificationEvent(string fullName, int userId, string emailAddress)
        {
            FullName = fullName;
            UserId = userId;
            EmailAddress = emailAddress;
        }

        public string FullName { get; private set; }
        public int UserId { get; private set; }
        public string EmailAddress { get; private set; }
    }
}
