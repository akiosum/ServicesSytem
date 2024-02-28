using CrmSystem.Configuration;
using CrmSystem.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddConfig(builder.Configuration)
    .AddRepository();

builder.Services.AddTransient<GlobalExceptionsMiddleware>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionsMiddleware>();
app.UseHttpsRedirection();
app.UseCors("Productions");
app.UseAuthorization();
app.MapControllers();
app.Run();