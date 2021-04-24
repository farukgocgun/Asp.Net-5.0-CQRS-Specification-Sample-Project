using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OFG.CqrsSample.Domain.Entities;

namespace OFG.CqrsSample.Infrastructure.Config
{
    public class ToDoItemCommentConfiguration : IEntityTypeConfiguration<TodoComment>
    {
        public void Configure(EntityTypeBuilder<TodoComment> builder)
        {
            builder.HasQueryFilter(p => p.DeletedDateTime == null);
        }
    }
}