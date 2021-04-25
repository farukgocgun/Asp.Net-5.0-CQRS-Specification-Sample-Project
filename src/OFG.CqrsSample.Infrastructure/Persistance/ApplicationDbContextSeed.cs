using Microsoft.Extensions.Logging;
using OFG.CqrsSample.Domain.Entities;
using OFG.CqrsSample.Infrastructure.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OFG.CqrsSample.Infrastructure.Persistance
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedTodoItemsAsync(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {

            try
            {
                if (!context.ToDoItems.Any())
                {
                    List<ToDoComment> comments = new List<ToDoComment>();
                    comments.Add(new ToDoComment() { Comment="comment for initial task" });
                    await context.ToDoItems.AddAsync(new ToDo()
                    {
                        Title = "Initial Task",
                        Description = "This item created by data seeder",
                        CreatedDateTime = DateTime.Now,
                        Comments= comments
                    });
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ApplicationDbContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}