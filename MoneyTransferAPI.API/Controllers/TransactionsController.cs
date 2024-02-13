using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyTransferAPI.Core.Commands.Transaction;
using MoneyTransferAPI.Core.Queries.Transaction;

namespace MoneyTransferAPI.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> CreateTransfer(CreateTransactionCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.StatusCode >= 200 && result.StatusCode <= 299)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var query = new GetAllTransactionsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetTransactionById(Guid id)
        //{
        //    var query = new GetTransactionByIdQuery { TransactionId = id };
        //    var result = await _mediator.Send(query);
        //    return result != null ? Ok(result) : NotFound();
        //}

    }
}