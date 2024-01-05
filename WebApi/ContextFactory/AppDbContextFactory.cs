using Database;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace WebApi.ContextFactory
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"),
               b => b.MigrationsAssembly("WebApi"));

            return new AppDbContext(builder.Options);
        }
    }
}
