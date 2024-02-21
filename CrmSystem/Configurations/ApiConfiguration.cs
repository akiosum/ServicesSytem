using Serilog;

namespace CrmSystem.Configurations;

public static class ApiConfiguration
{
    public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers()
            .ConfigureApiBehaviorOptions(conf => { conf.SuppressModelStateInvalidFilter = true; });
        services.AddEndpointsApiExplorer();
        services.AddSwagger();
        services.AddCors(options => options.AddPolicy("Productions",
            cors => cors
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()));

        services.AddLogging(options =>
        {
            options.ClearProviders();
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            options.AddSerilog(logger);
        });

        return services;
    }
}