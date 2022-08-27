using AbcBlog.Domain.Constants;
using AbcBlog.Domain.Events.Users;
using AbcBlog.Domain.Exceptions;
using AbcBlog.Domain.SeedWorks;

namespace AbcBlog.Domain.Aggregates.Users
{
    public class User : BaseEntity<int>, IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string FullName => $"{FirstName} {LastName}";

        public string Email { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsDeleted { get; private set; }
        public bool IsEmailVerified { get; private set; }
        public string Password { get; private set; }
        public string PasswordSalt { get; private set; }

        private User(string firstName, string lastName, string email, DateTime createdDate, bool isActive, bool isDeleted, bool isEmailVerified, string password, string passwordSalt)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CreatedDate = createdDate;
            IsActive = isActive;
            IsDeleted = isDeleted;
            IsEmailVerified = isEmailVerified;
            Password = password;
            PasswordSalt = passwordSalt;
        }


        public static User Load(string firstName, string lastName, string email, bool isActive, bool isDeleted, bool isEmailVerified, string password, string passwordSalt)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new DomainException(nameof(DomainErrorCode.Error1), DomainErrorCode.Error1);

            if (string.IsNullOrEmpty(lastName))
                throw new DomainException(nameof(DomainErrorCode.Error2), DomainErrorCode.Error2);

            if (string.IsNullOrEmpty(email))
                throw new DomainException(nameof(DomainErrorCode.Error3), DomainErrorCode.Error3);

            return new User(firstName, lastName, email, DateTime.Now, isActive, isDeleted, isEmailVerified, password, passwordSalt);
        }

        public User ChangeIsActive(bool isActive)
        {
            IsActive = isActive;
            return this;
        }

        public User ChangeIsDeleted()
        {
            IsDeleted = true;

            var eventItem = new UserDeletedEvent(Id);
            AddDomainEvent(eventItem);

            return this;
        }

        public User SendEmailVerification()
        {
            var eventItem = new UserEmailVerificationEvent(FullName, Id, Email);
            AddDomainEvent(eventItem);
            return this;
        }

        public User Update(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new DomainException(nameof(DomainErrorCode.Error1), DomainErrorCode.Error1);

            if (string.IsNullOrEmpty(lastName))
                throw new DomainException(nameof(DomainErrorCode.Error2), DomainErrorCode.Error2);

            FirstName = firstName;
            LastName = lastName;
            return this;
        }

        public User ChangeEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new DomainException(nameof(DomainErrorCode.Error3), DomainErrorCode.Error3);

            Email = email;
            IsEmailVerified = false;

            var eventItem = new UserEmailVerificationEvent($"{FirstName} {LastName}", Id, Email);
            AddDomainEvent(eventItem);

            return this;
        }

    }
}
