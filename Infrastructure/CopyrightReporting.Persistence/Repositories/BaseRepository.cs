using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Domain.Entities.Commons;
using CopyrightReporting.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CopyrightReporting.Persistence.Repositories
{
    public class BaseRepository<T>(CopyrightReportingDbContext _context) : IBaseRepository<T> where T : BaseEntity
    {
        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> AddAsync(T entity)
            => (await Table.AddAsync(entity)).Entity;  

        public async Task<T> DeleteAsync(int id)
        {
            T deletedEntity = await GetAsync(id);
            deletedEntity.IsActive = false;
            return deletedEntity;
        }

        public async Task<IQueryable<T>> GetAllAsync()
            => Table.AsQueryable();

        public async Task<T> GetAsync(int id)
            => await Table.FindAsync(id);

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public async Task<T> UpdateAsync(T entity)
            => Table.Update(entity).Entity;
    }
}
