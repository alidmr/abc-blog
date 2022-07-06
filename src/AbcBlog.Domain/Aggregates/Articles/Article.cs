using AbcBlog.Domain.Constants;
using AbcBlog.Domain.Exceptions;
using AbcBlog.Domain.SeedWorks;

namespace AbcBlog.Domain.Aggregates.Articles
{
    public class Article : BaseEntity<Guid>, IAggregateRoot
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public Guid OwnerId { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public bool IsDeleted { get; private set; }
        public bool IsActive { get; private set; }

        private Article(string title, string description, Guid ownerId, DateTime createdDate, bool isActive, bool isDeleted)
        {
            Title = title;
            Description = description;
            OwnerId = ownerId;
            CreatedDate = createdDate;
            IsActive = isActive;
            IsDeleted = isDeleted;
        }

        private Article(Guid id, string title, string description, Guid ownerId, DateTime createdDate, bool isActive,
            bool isDeleted)
        {
            Id = id;
            Title = title;
            Description = description;
            OwnerId = ownerId;
            CreatedDate = createdDate;
            IsActive = isActive;
            IsDeleted = isDeleted;
        }

        public static Article Load(Guid id, string title, string description, Guid ownerId, DateTime createdDate,
            bool isActive, bool isDeleted)
        {
            if (id == null || id == Guid.Empty)
                throw new DomainException(nameof(DomainErrorCode.Error5), DomainErrorCode.Error5);

            if (string.IsNullOrEmpty(title))
                throw new DomainException(nameof(DomainErrorCode.Error6), DomainErrorCode.Error6);

            if (string.IsNullOrEmpty(description))
                throw new DomainException(nameof(DomainErrorCode.Error7), DomainErrorCode.Error7);

            if (ownerId == null || ownerId == Guid.Empty)
                throw new DomainException(nameof(DomainErrorCode.Error8), DomainErrorCode.Error8);

            if (createdDate == DateTime.MinValue)
                throw new DomainException(nameof(DomainErrorCode.Error9), DomainErrorCode.Error9);

            return new Article(id, title, description, ownerId, createdDate, isActive, isDeleted);
        }

        public static Article Load(string title, string description, Guid ownerId, DateTime createdDate,
            bool isActive, bool isDeleted)
        {
            if (string.IsNullOrEmpty(title))
                throw new DomainException(nameof(DomainErrorCode.Error6), DomainErrorCode.Error6);

            if (string.IsNullOrEmpty(description))
                throw new DomainException(nameof(DomainErrorCode.Error7), DomainErrorCode.Error7);

            if (ownerId == null && ownerId == Guid.Empty)
                throw new DomainException(nameof(DomainErrorCode.Error8), DomainErrorCode.Error8);

            if (createdDate == DateTime.MinValue)
                throw new DomainException(nameof(DomainErrorCode.Error9), DomainErrorCode.Error9);

            return new Article(title, description, ownerId, createdDate, isActive, isDeleted);
        }

    }
}
