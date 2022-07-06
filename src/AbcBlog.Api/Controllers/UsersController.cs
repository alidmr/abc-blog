﻿using System.Net;
using AbcBlog.Api.Application.Commands.Users.Create;
using AbcBlog.Api.Application.Commands.Users.Delete;
using AbcBlog.Api.Application.Commands.Users.Update;
using AbcBlog.Api.Application.Queries.GetUserById;
using AbcBlog.Api.Application.Queries.GetUsers;
using AbcBlog.Shared.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbcBlog.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> CreateUser([FromServices] IMediator mediator, CreateUserCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetUserById([FromServices] IMediator mediator, Guid userId, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new GetUserByIdQuery(userId), cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromServices] IMediator mediator, int page, int pageSize,
            CancellationToken cancellationToken)
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
        public async Task<IActionResult> DeleteUser([FromServices] IMediator mediator, Guid userId,
            CancellationToken cancellationToken)
        {
            var result = await mediator.Send(new DeleteUserCommand(userId), cancellationToken);
            return Ok(result);
        }
    }
}