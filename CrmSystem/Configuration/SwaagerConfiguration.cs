using System.Reflection;
using Microsoft.OpenApi.Models;

namespace CrmSystem.Configuration;

public static class SwaagerConfiguration
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(swagger =>
        {
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "CRM System Study",
                Version = "V1",
                Description = "API for study",
                Contact = new OpenApiContact { Name = "Akio Serizawa" }
            });
        });

        return services;
    }

    public static void UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}