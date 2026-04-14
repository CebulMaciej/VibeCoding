using VibeCoding.Domain.Entities;

namespace VibeCoding.Application.Interfaces;

public interface IHealthService
{
    HealthStatus GetHealthStatus();
}
