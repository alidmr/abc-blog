using MediatR;

namespace AbcBlog.Api.Application.Commands.Articles.Update
{
    public class UpdateArticleCommand : IRequest<UpdateArticleCommandResult>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
