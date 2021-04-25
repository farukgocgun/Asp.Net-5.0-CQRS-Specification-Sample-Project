using OFG.CqrsSample.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OFG.CqrsSample.Infrastructure.Abstractions
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListWithSpecAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(ICollection<T> entities);
        Task<bool> AnyAsync();
        Task<bool> AnyAsync(ISpecification<T> spec);
        Task<int> SaveChangesAsync();
    }
}
