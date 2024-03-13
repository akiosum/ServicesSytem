using Prometheus;

namespace CrmSystem.Configuration;

public static class MetricsConfiguration
{
    public static IServiceCollection AddPrometheus(this IServiceCollection services)
    {
        services.UseHttpClientMetrics();

        return services;
    }

    public static void UsePrometheus(this IApplicationBuilder app)
    {
        app.UseMetricServer();
        app.UseHttpMetrics();
        app.UseRouting();
        app.UseEndpoints(endpoint =>
        {
            endpoint.MapControllers();
            endpoint.MapMetrics();
        });
    }
}