using AbcBlog.Domain.Constants;
using AbcBlog.Domain.Exceptions;
using AbcBlog.Domain.SeedWorks;
using AbcBlog.Shared.Helpers;

namespace AbcBlog.Domain.Aggregates.Articles
{
    public class Article : BaseEntity<int>, IAggregateRoot
    {
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public string Description { get; private set; }
        public int CreatedUserId { get; private set; }

        private int _statusId;

        public ArticleStatus Status { get; private set; }
        public DateTime CreatedDate { get; private set; }


        private Article(string title, string description, int createdUserId, int statusId, DateTime createdDate)
        {
            Title = title;
            Description = description;
            CreatedUserId = createdUserId;
            _statusId = statusId;
            CreatedDate = createdDate;
            Status = ArticleStatus.FromId(statusId);
        }

        public static Article Load(string title, string description, int createdUserId)
        {
            if (string.IsNullOrEmpty(title))
                throw new DomainException(nameof(DomainErrorCode.Error6), DomainErrorCode.Error6);

            if (string.IsNullOrEmpty(description))
                throw new DomainException(nameof(DomainErrorCode.Error7), DomainErrorCode.Error7);

            if (createdUserId <= 0)
                throw new DomainException(nameof(DomainErrorCode.Error8), DomainErrorCode.Error8);

            return new Article(title, description, createdUserId, ArticleStatus.Active.Id, DateTime.Now);
        }

        public Article SetSlug()
        {
            var randomId = BlogHelper.GetRandom();
            Slug = $"{BlogHelper.OptimizeText(Title)}-{randomId.ToString()}";
            return this;
        }

        public Article Update(string title, string description)
        {
            if (string.IsNullOrEmpty(title))
                throw new DomainException(nameof(DomainErrorCode.Error6), DomainErrorCode.Error6);

            if (string.IsNullOrEmpty(description))
                throw new DomainException(nameof(DomainErrorCode.Error7), DomainErrorCode.Error7);

            Title = title;
            Description = description;
            return this;
        }

        public Article Delete()
        {
            Status = ArticleStatus.Deleted;
            _statusId = ArticleStatus.Deleted.Id;
            return this;
        }

    }
}
