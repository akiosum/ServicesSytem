using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CrmSystem.Infrastructure.Data;

public class MigrationsRunner<TContext> : IHostedService
    where TContext : DbContext
{
    private readonly ILogger<MigrationsRunner<TContext>> _logger;
    private readonly IServiceScopeFactory _scopeFactory;

    public MigrationsRunner(ILogger<MigrationsRunner<TContext>> logger, IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Aplicando migrações!!!");

            await using var scope = _scopeFactory.CreateAsyncScope();

            var context = scope.ServiceProvider.GetRequiredService<TContext>();

            await context.Database.MigrateAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Falha ao criar migrações!!!");
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}