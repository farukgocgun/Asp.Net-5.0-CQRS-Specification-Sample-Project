using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OFG.CqrsSample.Domain.Entities;

namespace OFG.CqrsSample.Infrastructure.Config
{
    public class ToDoItemCommentConfiguration : IEntityTypeConfiguration<ToDoComment>
    {
        public void Configure(EntityTypeBuilder<ToDoComment> builder)
        {
            builder.HasQueryFilter(p => p.DeletedDateTime == null);
        }
    }
}