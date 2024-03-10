using Infrastrcture.Common;
using Infrastrcture.Persistance;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastrcture
{
    public static class Startup
    {
        public static IServiceCollection AddInfrastrcture(this IServiceCollection services,IConfiguration config)
        {
            return services
                .AddServices()
                .AddPersistance(config)
                .AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
