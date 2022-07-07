using AbcBlog.Domain.Aggregates.Articles;
using AbcBlog.Domain.Interfaces.Articles;
using AbcBlog.Infrastructure.Context;

namespace AbcBlog.Infrastructure.Repository.Articles
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(AbcBlogContext context) : base(context)
        {
        }
    }
}
