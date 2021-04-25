using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OFG.CqrsSample.Application.Features.ToDoComment.Commands.CreateToDoComment;
using OFG.CqrsSample.Application.Features.ToDoComment.Commands.DeleteToDoComment;
using OFG.CqrsSample.Application.Features.ToDoComment.Commands.UpdateToDoComment;
using OFG.CqrsSample.Application.Features.ToDoComment.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OFG.CqrsSample.API.Controllers
{
    public class ToDoCommentController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ToDoCommentController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ToDoCommentResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<ToDoCommentResponse>> Get(int id)
        {
            var query = new GetToDoCommentbyIdWithQuery(id);
            return Ok(await _mediator.Send(query));
        }

 
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ToDoCommentResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ToDoCommentResponse>>> GetList([FromQuery] GetToDoCommentListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Create([FromBody] CreateToDoCommentCommand command)
        {
            Response.StatusCode = StatusCodes.Status201Created;
            return await _mediator.Send(command);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateToDoCommentCommand command)
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
            var command = new DeleteToDoCommentCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
