using MediatR;

namespace OFG.CqrsSample.Application.Features.ToDoComment.Commands.CreateToDoComment
{
    public class CreateToDoCommentCommand : IRequest<int>
    {
        public int TodoId { get; set; }
        public string Comment { get; set; }
    }
}