using Application.Common.Persistence;
using Infrastrcture.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastrcture.Common
{
    public static class Startup
    {
        public static IServiceCollection AddServices(this IServiceCollection Service)
        {
            return Service
                .AddScoped<ITodoRepository, TodoRepository>();
        }
    }
}
