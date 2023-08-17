using Application.Items.Create;
using Application.Items.GetAll;
using Application.Items.Update;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("items")]
    public class ItemsController : ApiController
    {
        private readonly ISender _mediator;

        public ItemsController(ISender mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet("GetItems")]
        public async Task<IActionResult> GetAllAsync()
        {
            var itemsResult = await _mediator.Send(new GetAllItemsQuery());

            return itemsResult.Match(
                items => Ok(items),
                errors => Problem(errors)
            );
        }

     
        [HttpPost("CreateItem")]
        public async Task<IActionResult> Create([FromBody] CreateItemCommand command)
        {
            var createResult = await _mediator.Send(command);

            return createResult.Match(
                itemId => Ok(itemId),
                errors => Problem(errors)
            );
        }

        [HttpPut("UpdateItem/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateItemCommand command)
        {
            if (command.Id != id)
            {
                List<Error> errors = new()
            {
                Error.Validation("Item UpdateInvalid", "The request Id does not match with the url Id.")
            };
                return Problem(errors);
            }

            var updateResult = await _mediator.Send(command);

            return updateResult.Match(
                itemId => NoContent(),
                errors => Problem(errors)
            );
        }

    }
}
