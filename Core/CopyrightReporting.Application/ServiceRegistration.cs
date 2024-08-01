using Microsoft.Extensions.DependencyInjection;

namespace CopyrightReporting.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Scoped);
        }
    }
}
