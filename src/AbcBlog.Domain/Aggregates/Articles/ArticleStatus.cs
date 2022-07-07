using AbcBlog.Domain.Constants;
using AbcBlog.Domain.Exceptions;
using AbcBlog.Domain.SeedWorks;

namespace AbcBlog.Domain.Aggregates.Articles
{
    public class ArticleStatus : Enumeration
    {
        public static ArticleStatus WaitingApprove = new ArticleStatus(1, nameof(WaitingApprove).ToLower());
        public static ArticleStatus Passive = new ArticleStatus(2, nameof(Passive).ToLower());
        public static ArticleStatus Active = new ArticleStatus(3, nameof(Active).ToLower());
        public static ArticleStatus Deleted = new ArticleStatus(4, nameof(Deleted).ToLower());

        public ArticleStatus(int id, string name) : base(id, name)
        {
        }

        public static IEnumerable<ArticleStatus> List()
        {
            return new[]
            {
                WaitingApprove,
                Passive,
                Active,
                Deleted
            };
        }

        public static ArticleStatus FromName(string name)
        {
            var status = List()
                .FirstOrDefault(x => string.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase));
            if (status == null)
            {
                throw new DomainException(nameof(DomainErrorCode.Error11), string.Format(DomainErrorCode.Error11, name));
            }
            return status;
        }

        public static ArticleStatus FromId(int id)
        {
            var status = List().FirstOrDefault(x => x.Id == id);

            if (status == null)
            {
                throw new DomainException(nameof(DomainErrorCode.Error11), string.Format(DomainErrorCode.Error11, id));
            }

            return status;
        }

    }
}
