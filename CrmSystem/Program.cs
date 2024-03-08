using CrmSystem.Configuration;
using CrmSystem.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddConfig(builder.Configuration)
    . AddInjectDependency();

builder.Services.AddTransient<GlobalExceptionsMiddleware>();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionsMiddleware>();
app.UseHttpsRedirection();
app.UseCors("Productions");
app.UseSwaggerDocumentation();
app.UseAuthorization();
app.MapControllers();
app.Run();