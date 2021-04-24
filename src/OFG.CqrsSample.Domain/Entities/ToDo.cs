using OFG.CqrsSample.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OFG.CqrsSample.Domain.Entities
{
    public class ToDo : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsCompleted { get; set; } = false;
        public ICollection<TodoComment> Comments { get; set; }

    }
}
