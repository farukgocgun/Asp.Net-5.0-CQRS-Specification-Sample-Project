using OFG.CqrsSample.Infrastructure.Extensions;
using OFG.CqrsSample.Infrastructure.Specifications;

namespace OFG.CqrsSample.Application.Features.ToDoComment.Queries
{
    public class ToDoCommentSpec : BaseSpecification<Domain.Entities.ToDoComment>
    {
        public ToDoCommentSpec(GetToDoCommentListQuery query) : base(x =>
              (!query.ToDoId.HasValue || x.TodoId.Equals(query.ToDoId))
              && (!query.Comment.HasValue() || x.Comment.ToLower().Contains(query.Comment))
          )
        {
            AddOrderByDescending(x => x.CreatedDateTime);
            ApplyPaging(query.PageSize * (query.PageIndex - 1), query.PageSize);

            if (!string.IsNullOrEmpty(query.Sort))
            {
                switch (query.Sort)
                {
                    case "createdDateAsc":
                        AddOrderBy(p => p.CreatedDateTime);
                        break;
                    case "createdDateDesc":
                        AddOrderByDescending(p => p.CreatedDateTime);
                        break;
                }
            }
        }
        /// <summary>
        /// If you want to include an entity to this spec, you must to use AddInclude function for instance: AddInclude(x => x.Category) 
        /// </summary>
        public ToDoCommentSpec(int Id) : base(x => x.Id == Id)
        {
        }
    }
}