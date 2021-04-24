using MediatR;

namespace OFG.CqrsSample.Application.Features.ToDo.Queries
{
    public class GetToDobyIdWithQuery : IRequest<ToDoResponse>
    {
        public GetToDobyIdWithQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
