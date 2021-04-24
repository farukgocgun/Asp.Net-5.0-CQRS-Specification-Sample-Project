using OFG.CqrsSample.Infrastructure.Extensions;
using OFG.CqrsSample.Infrastructure.Specifications;

namespace OFG.CqrsSample.Application.Features.ToDo.Queries
{
    public class ToDoWithFiltersForCountSpec : BaseSpecification<Domain.Entities.ToDo>
    {
        public ToDoWithFiltersForCountSpec(GetToDoListQuery query)
            : base(x =>
                   (!query.Title.HasValue() || x.Title.ToLower().Contains(query.Title))
              && (!query.Description.HasValue() || x.Description.ToLower().Contains(query.Description))
            )
        {

        }

    }
}
