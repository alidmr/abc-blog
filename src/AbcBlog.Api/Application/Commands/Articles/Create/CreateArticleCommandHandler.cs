using AbcBlog.Api.Application.Commands.Articles.Create.Dtos;
using AbcBlog.Domain.Aggregates.Articles;
using AbcBlog.Domain.Interfaces.Articles;
using MediatR;

namespace AbcBlog.Api.Application.Commands.Articles.Create
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, CreateArticleCommandResult>
    {
        private readonly IArticleRepository _articleRepository;

        public CreateArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<CreateArticleCommandResult> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var article = Article.Load(request.Title, request.Description, request.CreatedUserId);

            article.SetSlug();

            await _articleRepository.AddAsync(article);

            var result =await _articleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return new CreateArticleCommandResult()
            {
                Message = "İşlem başarılı",
                Result = new CreateArticleDto()
                {
                    Id = article.Id
                }
            };
        }
    }
}
