namespace OFG.CqrsSample.Application.Features.ToDo.Commands.UpdateToDo
{
    public class UpdateToDoCommentCommand
    {
        public int Id { get; set; }
        public int TodoId { get; set; }
        public string Comment { get; set; }
    }
}