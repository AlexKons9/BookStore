using Infrastructure.Repositories.Manager;
using Microsoft.Extensions.DependencyInjection;
using RepositoryInterfaces.RepositoryInterfaces.IManager;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IManagerRepository, ManagerRepository>();
            return services;
        }
    }
}
