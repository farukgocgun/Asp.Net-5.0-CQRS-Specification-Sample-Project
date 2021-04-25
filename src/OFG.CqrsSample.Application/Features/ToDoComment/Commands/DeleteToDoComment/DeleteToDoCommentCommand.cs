using MediatR;

namespace OFG.CqrsSample.Application.Features.ToDoComment.Commands.DeleteToDoComment
{
    public class DeleteToDoCommentCommand : IRequest
    {
        public int Id { get; set; }
        public bool? isSoftDelete { get; set; }
    }
}
