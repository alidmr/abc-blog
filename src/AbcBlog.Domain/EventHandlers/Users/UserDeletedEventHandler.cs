using AbcBlog.Domain.Aggregates.Articles;
using AbcBlog.Domain.Events.Users;
using AbcBlog.Domain.Interfaces.Articles;
using MediatR;

namespace AbcBlog.Domain.EventHandlers.Users
{
    public class UserDeletedEventHandler : INotificationHandler<UserDeletedEvent>
    {
        private readonly IArticleRepository _articleRepository;

        public UserDeletedEventHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task Handle(UserDeletedEvent notification, CancellationToken cancellationToken)
        {
            //var userArticles = await _articleRepository
            //    .GetAllAsync(x => x.CreatedUserId == notification.UserId 
            //                      && x.Status != ArticleStatus.Deleted);

            var userArticles = await _articleRepository
                .GetAllAsync(x => x.CreatedUserId == notification.UserId);

            if (userArticles.Any())
            {
                foreach (var article in userArticles)
                {
                    article.Delete();
                }

                await _articleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
