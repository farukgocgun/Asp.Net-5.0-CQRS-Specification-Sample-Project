using System;
using System.Collections.Generic;

namespace OFG.CqrsSample.Application.Features.ToDo.Queries
{
    public class ToDoResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? CreatedDateTime { get; set; }
        public ICollection<ToDoCommentResponse> Comments { get; set; }
    }
}