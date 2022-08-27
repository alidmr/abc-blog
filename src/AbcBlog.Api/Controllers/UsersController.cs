using AbcBlog.Api.Application.Commands.Users.ChangeEmail;
using AbcBlog.Api.Application.Commands.Users.Delete;
using AbcBlog.Api.Application.Commands.Users.Update;
using AbcBlog.Api.Application.Queries.Users.GetUserById;
using AbcBlog.Api.Application.Queries.Users.GetUsers;
using AbcBlog.Shared.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbcBlog.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetUserById([FromServices] IMediator mediator, int userId, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetUserByIdQuery(userId), cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromServices] IMediator mediator,
            CancellationToken cancellationToken, int page, int pageSize)
        {
            var result = await mediator.Send(new GetUsersQuery(page, pageSize), cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromServices] IMediator mediator, UpdateUserCommand command,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromServices] IMediator mediator, int userId,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new DeleteUserCommand(userId), cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [Route("change-email")]
        public async Task<IActionResult> ChangeUserEmail([FromServices] IMediator mediator, ChangeUserEmailCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
