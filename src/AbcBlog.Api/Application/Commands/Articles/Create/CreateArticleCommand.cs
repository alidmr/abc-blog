using MediatR;

namespace AbcBlog.Api.Application.Commands.Articles.Create
{
    public class CreateArticleCommand : IRequest<CreateArticleCommandResult>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreatedUserId { get; set; }
    }
}
