using AbcBlog.Domain.Constants;
using AbcBlog.Domain.Events.Users;
using AbcBlog.Domain.Exceptions;
using AbcBlog.Domain.SeedWorks;

namespace AbcBlog.Domain.Aggregates.Users
{
    public class User : BaseEntity<Guid>, IAggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsDeleted { get; private set; }
        public string Password { get; private set; }
        public string PasswordSalt { get; private set; }

        private User(string firstName, string lastName, string email, DateTime createdDate, bool isActive, bool isDeleted, string password, string passwordSalt)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CreatedDate = createdDate;
            IsActive = isActive;
            IsDeleted = isDeleted;
            Password = password;
            PasswordSalt = passwordSalt;
        }

        private User(Guid id, string firstName, string lastName, string email, DateTime createdDate, bool isActive, bool isDeleted, string password, string passwordSalt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            CreatedDate = createdDate;
            IsActive = isActive;
            IsDeleted = isDeleted;
            Password = password;
            PasswordSalt = passwordSalt;
        }

        public static User Load(string firstName, string lastName, string email, bool isActive, bool isDeleted, string password, string passwordSalt)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new DomainException(nameof(DomainErrorCode.Error1), DomainErrorCode.Error1);

            if (string.IsNullOrEmpty(lastName))
                throw new DomainException(nameof(DomainErrorCode.Error2), DomainErrorCode.Error2);

            if (string.IsNullOrEmpty(email))
                throw new DomainException(nameof(DomainErrorCode.Error3), DomainErrorCode.Error3);

            return new User(firstName, lastName, email, DateTime.Now, isActive, isDeleted, password, passwordSalt);
        }

        public static User Load(Guid id, string firstName, string lastName, string email, bool isActive, bool isDeleted, string password, string passwordSalt)
        {
            if (id == null || id == Guid.Empty)
                throw new DomainException(nameof(DomainErrorCode.Error4), DomainErrorCode.Error4);

            if (string.IsNullOrEmpty(firstName))
                throw new DomainException(nameof(DomainErrorCode.Error1), DomainErrorCode.Error1);

            if (string.IsNullOrEmpty(lastName))
                throw new DomainException(nameof(DomainErrorCode.Error2), DomainErrorCode.Error2);

            if (string.IsNullOrEmpty(email))
                throw new DomainException(nameof(DomainErrorCode.Error3), DomainErrorCode.Error3);

            return new User(id, firstName, lastName, email, DateTime.Now, isActive, isDeleted, password, passwordSalt);
        }

        public User ChangeIsActive(bool isActive)
        {
            this.IsActive = isActive;

            var eventItem = new UserChangeIsActiveEvent(this.Id, isActive);
            AddDomainEvent(eventItem);
            return this;
        }

        public User ChangeIsDeleted()
        {
            this.IsDeleted = true;

            var eventItem = new UserDeletedEvent(this.Id);
            AddDomainEvent(eventItem);
            return this;
        }

    }
}
