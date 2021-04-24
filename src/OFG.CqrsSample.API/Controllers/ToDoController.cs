using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OFG.CqrsSample.Application.Features.ToDo.Commands.CreateToDo;
using OFG.CqrsSample.Application.Features.ToDo.Commands.DeleteToDo;
using OFG.CqrsSample.Application.Features.ToDo.Commands.UpdateToDo;
using OFG.CqrsSample.Application.Features.ToDo.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OFG.CqrsSample.API.Controllers
{
    public class ToDoController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ToDoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ToDoResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ToDoResponse>> Get(int id)
        {
            var query = new GetToDobyIdWithQuery(id);
            return Ok(await _mediator.Send(query));
        }

 
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ToDoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ToDoResponse>>> GetList([FromQuery] GetToDoListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Create([FromBody] CreateToDoCommand command)
        {
            Response.StatusCode = StatusCodes.Status201Created;
            return await _mediator.Send(command);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateToDoCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteToDoCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
