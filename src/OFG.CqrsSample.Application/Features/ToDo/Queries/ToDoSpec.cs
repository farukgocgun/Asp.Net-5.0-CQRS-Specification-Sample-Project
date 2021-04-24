using OFG.CqrsSample.Infrastructure.Extensions;
using OFG.CqrsSample.Infrastructure.Specifications;

namespace OFG.CqrsSample.Application.Features.ToDo.Queries
{
    public class ToDoSpec : BaseSpecification<Domain.Entities.ToDo>
    {
        public ToDoSpec(GetToDoListQuery query) : base(x =>
              (!query.Title.HasValue() || x.Title.ToLower().Contains(query.Title))
              && (!query.Description.HasValue() || x.Description.ToLower().Contains(query.Description))
          )
        {
            AddInclude(x => x.Comments);
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
        public ToDoSpec(int Id) : base(x => x.Id == Id)
        {
            AddInclude(x => x.Comments);
        }
    }
}