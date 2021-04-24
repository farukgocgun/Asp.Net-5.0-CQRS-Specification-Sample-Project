namespace OFG.CqrsSample.Application.Features.ToDo.Queries
{
    public class ToDoCommentResponse
    {
        public int Id { get; set; }
        public int TodoId { get; set; }
        public string Comment { get; set; }
    }
}