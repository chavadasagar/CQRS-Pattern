using Infrastrcture.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastrcture.Persistance
{
    public static class Startup
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration config)
        {
            var databaseSettings = config.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettings>();
            string? rootConnectionString = databaseSettings.ConnectionString;
            if (string.IsNullOrEmpty(rootConnectionString))
            {
                throw new InvalidOperationException("DB ConnectionString is not configured.");
            }

            string? dbProvider = databaseSettings.DBProvider;
            if (string.IsNullOrEmpty(dbProvider))
            {
                throw new InvalidOperationException("DB Provider is not configured.");
            }

            return services
            .AddDbContext<ApplicationDbContext>(m => m.UseSqlServer(rootConnectionString,e => e.MigrationsAssembly("Infrastrcture")));
        }
    }
}
