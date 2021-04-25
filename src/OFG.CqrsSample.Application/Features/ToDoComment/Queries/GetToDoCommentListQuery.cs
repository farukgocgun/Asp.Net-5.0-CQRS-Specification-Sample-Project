using OFG.CqrsSample.Application.Helpers;
using MediatR;
using OFG.CqrsSample.Infrastructure.Specifications;

namespace OFG.CqrsSample.Application.Features.ToDoComment.Queries
{
    public class GetToDoCommentListQuery : BaseSpecificationParams, IRequest<Pagination<ToDoCommentResponse>>
    {
        public int? ToDoId { get; set; }
        public string Comment { get; set; }
    }
}
