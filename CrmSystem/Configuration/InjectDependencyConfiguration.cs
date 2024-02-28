using CrmSystem.Application;
using CrmSystem.Infrastructure;
using CrmSystem.Infrastructure.Abstractions;

namespace CrmSystem.Configuration;

public static class InjectDependencyConfiguration
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.Scan(scan =>
            scan.FromAssemblies(ApplicationAssembly.Assembly, InfraAssembly.Assembly)
                .AddClasses(filter => filter.AssignableTo<IBaseRepository>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        return services;
    }
}