using AbcBlog.Api.Application.Commands.Accounts.Login;
using AbcBlog.Api.Application.Commands.Accounts.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AbcBlog.Api.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


    }
}
