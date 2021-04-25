using MediatR;

namespace OFG.CqrsSample.Application.Features.ToDoComment.Commands.UpdateToDoComment
{
    public class UpdateToDoCommentCommand : IRequest
    {
        public int Id { get; set; }
        public int TodoId { get; set; }
        public string Comment { get; set; }
    }
}