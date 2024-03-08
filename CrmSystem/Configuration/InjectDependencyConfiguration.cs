using CrmSystem.Application;
using CrmSystem.Application.Contracts.Infrastructure;
using CrmSystem.Infrastructure;
using CrmSystem.Infrastructure.Abstractions;

namespace CrmSystem.Configuration;

public static class InjectDependencyConfiguration
{
    public static IServiceCollection AddInjectDependency(this IServiceCollection services)
    {
        services
            .AddRepository()
            .AddInfrastructure();

        return services;
    }

    private static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.Scan(scan =>
            scan.FromAssemblies(ApplicationAssembly.Assembly, InfraAssembly.Assembly)
                .AddClasses(filter => filter.AssignableTo<IBaseRepository>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        return services;
    }

    private static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.Scan(scan =>
            scan.FromAssemblies(ApplicationAssembly.Assembly, InfraAssembly.Assembly)
                .AddClasses(filter => filter.AssignableTo<IBaseInfrastructure>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        return services;
    }
}