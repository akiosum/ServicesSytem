using System.Text.Json;
using CrmSystem.Application.Dto.HealthCheck;
using CrmSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Prometheus;

namespace CrmSystem.Configuration;

public static class HealthChecksConfguration
{
    public static IServiceCollection AddApiHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>()
            .ForwardToPrometheus();

        return services;
    }

    public static void UseHealthChecks(this IApplicationBuilder app)
    {
        app.UseHealthChecks("/status", new HealthCheckOptions
        {
            ResponseWriter = async (context, report) =>
            {
                context.Response.ContentType = "application/json";
                var response = new HealthCheckResponse(
                    report.Status.ToString(),
                    report.Entries.Select(x => new HealthCheck(x.Value.Status.ToString(), x.Key, x.Value.Description)),
                    report.TotalDuration);

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        });
    }
}