using CopyrightReporting.Domain.Entities;
using CopyrightReporting.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CopyrightReporting.Persistence.Contexts
{
    public class CopyrightReportingDbContext : DbContext
    {
        //public CopyrightReportingDbContext(DbContextOptions options) : base(options){ }
        public CopyrightReportingDbContext(DbContextOptions<CopyrightReportingDbContext> options) : base(options) { }   
        public CopyrightReportingDbContext() { }
       

        public DbSet<Artist> Artists { get; set; }
        public DbSet<ListenLog> ListenLogs { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<MusicType> MusicTypes { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Provider> Providers { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Artist>()
                .Property(a => a.Name)
                .HasMaxLength(50);
      

            base.OnModelCreating(modelBuilder);

        }

        
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
