using VibeCoding.Application.Interfaces;
using VibeCoding.Domain.Entities;

namespace VibeCoding.Infrastructure.Services;

public class HealthService : IHealthService
{
    private const string AppVersion = "1.0.0";

    public HealthStatus GetHealthStatus()
    {
        return new HealthStatus
        {
            Status = "Healthy",
            CheckedAt = DateTime.UtcNow,
            Version = AppVersion
        };
    }
}
