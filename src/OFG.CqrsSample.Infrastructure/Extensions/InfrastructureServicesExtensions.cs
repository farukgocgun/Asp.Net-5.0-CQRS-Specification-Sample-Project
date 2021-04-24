using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OFG.CqrsSample.Infrastructure.Abstractions;
using OFG.CqrsSample.Infrastructure.Persistance;
using OFG.CqrsSample.Infrastructure.Repositories;

namespace OFG.CqrsSample.Infrastructure.Extensions
{
    public static class InfrastructureServicesExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<ApplicationDbContext>(x =>
            {
                x.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}