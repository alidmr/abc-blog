using AbcBlog.Api.Application.Commands.Articles.Create.Dtos;

namespace AbcBlog.Api.Application.Commands.Articles.Create
{
    public class CreateArticleCommandResult : BaseCommandResult
    {
        public CreateArticleDto Result { get; set; }
    }
}
