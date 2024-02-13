using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyTransferAPI.Core.Commands.User;
using MoneyTransferAPI.Core.Queries.Transaction;
using MoneyTransferAPI.Core.Queries.User;

namespace MoneyTransferAPI.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginQuery query)
        {
            var response = await _mediator.Send(query);
            return response.Result ? Ok(response) : Unauthorized(response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            var query = new GetUserByIdQuery { UserId = id };
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        //Get user balance
        [HttpGet("{id}/balance")]
        public async Task<IActionResult> GetUserBalance(Guid id)
        {
            var query = new GetUserBalanceQuery { UserId = id };
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("{id}/transactions")]
        public async Task<IActionResult> GetUserTransactions(Guid id)
        {
            var query = new GetUserTransactionsQuery { UserId = id };
            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }
    }
}