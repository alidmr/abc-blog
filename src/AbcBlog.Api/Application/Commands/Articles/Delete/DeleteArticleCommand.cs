using MediatR;

namespace AbcBlog.Api.Application.Commands.Articles.Delete
{
    public class DeleteArticleCommand : IRequest<DeleteArticleCommandResult>
    {
        public DeleteArticleCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
