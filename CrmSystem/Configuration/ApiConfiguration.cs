using CrmSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CrmSystem.Configuration;

public static class ApiConfiguration
{
    public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers()
            .ConfigureApiBehaviorOptions(conf => { conf.SuppressModelStateInvalidFilter = true; });
        services.AddEndpointsApiExplorer();
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(Application.ApplicationAssembly.Assembly);
        });
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

        services.AddDatabase(configuration);
        services.AddApiHealthChecks();

        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Database")));

        services.AddHostedService<MigrationsRunner<ApplicationDbContext>>();

        return services;
    }
}