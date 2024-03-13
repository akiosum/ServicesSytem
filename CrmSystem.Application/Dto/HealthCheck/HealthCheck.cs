namespace CrmSystem.Application.Dto.HealthCheck;

public record HealthCheck(
    string Status,
    string Component,
    string? Description);
    
public record HealthCheckResponse(
    string Status,
    IEnumerable<HealthCheck> Checks,
    TimeSpan Duration);
