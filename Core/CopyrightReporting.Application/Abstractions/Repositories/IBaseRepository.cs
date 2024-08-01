using CopyrightReporting.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;

namespace CopyrightReporting.Application.Abstractions.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
        Task<T> GetAsync(int id);
        Task<IQueryable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
        Task<int> SaveAsync();
    }
}
