using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OFG.CqrsSample.Domain.Entities;

namespace OFG.CqrsSample.Infrastructure.Config
{
    public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasQueryFilter(p => p.DeletedDateTime == null);
        }
    }
}