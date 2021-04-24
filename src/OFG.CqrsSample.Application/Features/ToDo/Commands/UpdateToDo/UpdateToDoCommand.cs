using MediatR;
using System.Collections.Generic;

namespace OFG.CqrsSample.Application.Features.ToDo.Commands.UpdateToDo
{
    public class UpdateToDoCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public ICollection<UpdateToDoCommentCommand> Comments { get; set; }
    }
}
