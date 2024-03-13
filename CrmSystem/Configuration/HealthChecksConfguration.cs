using CrmSystem.Infrastructure.Data;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Prometheus;

namespace CrmSystem.Configuration;

public static class HealthChecksConfguration
{
    public static IServiceCollection AddApiHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>(tags: new[] { "Database" })
            .ForwardToPrometheus();

        services.AddHealthChecksUI()
            .AddInMemoryStorage();

        return services;
    }

    public static void UseHealthChecks(this IApplicationBuilder app)
    {
        app.UseHealthChecks("/status", new HealthCheckOptions
        {
            Predicate = _ => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        app.UseHealthChecksUI(options => { options.UIPath = "/dashboard"; });
    }
}