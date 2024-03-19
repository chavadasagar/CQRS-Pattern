using Application.Common.Interface;
using Application.Common.Persistence;
using Infrastrcture.Common.Services;
using Infrastrcture.Persistance;
using Infrastrcture.Persistance.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastrcture.Common
{
    public static class Startup
    {
        public static IServiceCollection AddServices(this IServiceCollection Service)
        {
            return Service
                .AddScoped<CQRSPatternContext>()
                .AddScoped<IEmployeeRepository, EmployeeRepository>()
                .AddScoped<ITodoRepository, TodoRepository>()
                .AddScoped<ISerializerService, NewtonSoftService>();
        }
    }
}
