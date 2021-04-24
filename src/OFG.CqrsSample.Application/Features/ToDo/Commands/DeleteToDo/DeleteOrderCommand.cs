using MediatR;

namespace OFG.CqrsSample.Application.Features.ToDo.Commands.DeleteToDo
{
    public class DeleteToDoCommand : IRequest
    {
        public int Id { get; set; }
        public bool? isSoftDelete { get; set; }
    }
}
