using OFG.CqrsSample.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace OFG.CqrsSample.Domain.Entities
{
    public class TodoComment : BaseEntity
    {
        [Required]
        public int TodoId { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
