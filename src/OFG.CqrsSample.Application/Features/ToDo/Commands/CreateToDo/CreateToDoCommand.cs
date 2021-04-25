,using MediatR;
using OFG.CqrsSample.Application.Features.ToDoComment.Commands.CreateToDoComment;
using System.Collections.Generic;

namespace OFG.CqrsSample.Application.Features.ToDo.Commands.CreateToDo
{
    public class CreateToDoCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public ICollection<CreateToDoCommentCommand> Comments { get; set; }
    }
}
