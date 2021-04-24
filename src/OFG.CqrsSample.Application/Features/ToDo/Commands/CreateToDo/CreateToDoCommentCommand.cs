namespace OFG.CqrsSample.Application.Features.ToDo.Commands.CreateToDo
{
    public class CreateToDoCommentCommand
    {
        public int TodoId { get; set; }
        public string Comment { get; set; }
    }
}