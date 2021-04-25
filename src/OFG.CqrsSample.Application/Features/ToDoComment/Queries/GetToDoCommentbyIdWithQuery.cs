using MediatR;

namespace OFG.CqrsSample.Application.Features.ToDoComment.Queries
{
    public class GetToDoCommentbyIdWithQuery : IRequest<ToDoCommentResponse>
    {
        public GetToDoCommentbyIdWithQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
