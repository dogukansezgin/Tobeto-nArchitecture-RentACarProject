using Core.CrossCuttingConcerns.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using System.Reflection;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("nArcRentACarConnectionString")));

        services.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .Where(t => t.ServiceType.Name.EndsWith("Repository"));

        return services;
    }
}
