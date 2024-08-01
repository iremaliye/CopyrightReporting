using CopyrightReporting.Domain.Entities;
using CopyrightReporting.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CopyrightReporting.Persistence.Contexts
{
    public class CopyrightReportingDbContext : DbContext
    {
        public CopyrightReportingDbContext(DbContextOptions options) : base(options){ }
        public CopyrightReportingDbContext() { }
       

        public DbSet<Artist> Artists { get; set; }
        public DbSet<ListenLog> ListenLogs { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<MusicType> MusicTypes { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Provider> Providers { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<EntityEntry<BaseEntity>>? datas = ChangeTracker.Entries<BaseEntity>();

            Parallel.ForEach(datas, data => 
            {
                if (data.State == EntityState.Added)
                {
                    data.Entity.CreatedDate = DateTime.UtcNow;
                    data.Entity.IsActive = true;
                }
                else if (data.State == EntityState.Modified)
                    data.Entity.UpdatedDate = DateTime.UtcNow;
            });

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
