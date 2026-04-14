namespace VibeCoding.Domain.Entities;

public class HealthStatus
{
    public string Status { get; init; } = string.Empty;
    public DateTime CheckedAt { get; init; }
    public string Version { get; init; } = string.Empty;
}
