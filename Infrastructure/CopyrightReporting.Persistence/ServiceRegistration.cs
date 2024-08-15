using CopyrightReporting.Application.Abstractions.Repositories;
using CopyrightReporting.Domain.Entities;
using CopyrightReporting.Persistence.Contexts;
using CopyrightReporting.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CopyrightReporting.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddDbContext<CopyrightReportingDbContext>(opt => opt.UseNpgsql(_configuration.GetConnectionString("PostgreSQL")));
            services.AddScoped<IBaseRepository<Provider>, BaseRepository<Provider>>();
            services.AddScoped<IBaseRepository<Package>, BaseRepository<Package>>();
            services.AddScoped<IBaseRepository<MusicType>, BaseRepository<MusicType>>();
            services.AddScoped<IBaseRepository<Music>, BaseRepository<Music>>();
            services.AddScoped<IBaseRepository<ListenLog>, BaseRepository<ListenLog>>();
            services.AddScoped<IBaseRepository<Artist>, BaseRepository<Artist>>();
            

        }
    }
}
