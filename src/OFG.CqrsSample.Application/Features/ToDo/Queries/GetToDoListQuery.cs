using OFG.CqrsSample.Application.Helpers;
using MediatR;
using OFG.CqrsSample.Infrastructure.Specifications;

namespace OFG.CqrsSample.Application.Features.ToDo.Queries
{
    public class GetToDoListQuery : BaseSpecificationParams, IRequest<Pagination<ToDoResponse>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
