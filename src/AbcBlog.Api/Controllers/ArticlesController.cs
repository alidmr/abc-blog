using AbcBlog.Api.Application.Commands.Articles.Create;
using AbcBlog.Api.Application.Commands.Articles.Delete;
using AbcBlog.Api.Application.Commands.Articles.Update;
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
        private readonly IMediator _mediator;

        public ArticlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? searchKey = null)
        {
            var result = await _mediator.Send(new GetArticlesQuery(page, pageSize, searchKey));
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetArticleById(int id)
        {
            var result = await _mediator.Send(new GetArticleByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateArticleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateArticleCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteArticleCommand(id));
            return Ok(result);
        }
    }
}
