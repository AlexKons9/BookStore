using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using RepositoryInterfaces.RepositoryInterfaces;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            return services;
        }
    }
}
