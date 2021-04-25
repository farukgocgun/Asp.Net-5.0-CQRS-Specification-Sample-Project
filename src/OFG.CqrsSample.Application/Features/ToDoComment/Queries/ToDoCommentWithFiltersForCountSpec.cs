using OFG.CqrsSample.Infrastructure.Extensions;
using OFG.CqrsSample.Infrastructure.Specifications;

namespace OFG.CqrsSample.Application.Features.ToDoComment.Queries
{
    public class ToDoCommentWithFiltersForCountSpec : BaseSpecification<Domain.Entities.ToDoComment>
    {
        public ToDoCommentWithFiltersForCountSpec(GetToDoCommentListQuery query)
            : base(x =>
                    (!query.ToDoId.HasValue || x.TodoId.Equals(query.ToDoId))
              && (!query.Comment.HasValue() || x.Comment.ToLower().Contains(query.Comment))
            )
        {

        }

    }
}
