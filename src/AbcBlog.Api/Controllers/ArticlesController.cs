using AbcBlog.Api.Application.Queries.Articles.GetArticleById;
using AbcBlog.Api.Application.Queries.Articles.GetArticles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AbcBlog.Api.Controllers
{
    [Route("api/articles")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetArticles([FromServices] IMediator mediator, [FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? searchKey)
        {
            var result = await mediator.Send(new GetArticlesQuery(page, pageSize, searchKey));
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetArticleById([FromServices] IMediator mediator, Guid id)
        {
            var result = await mediator.Send(new GetArticleByIdQuery(id));
            return Ok(result);
        }
    }
}
