using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyTransferAPI.Core.Commands.User;
using MoneyTransferAPI.Core.Queries.User;

namespace MoneyTransferAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok();
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login(UserLoginQuery query)
        //{
        //    var result = await _mediator.Send(query);
        //    return result.Success ? Ok(result) : Unauthorized(result.Message);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var query = new GetUserByIdQuery { UserId = id };
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        // Diðer gerekli endpointler buraya eklenecek...
    }

}