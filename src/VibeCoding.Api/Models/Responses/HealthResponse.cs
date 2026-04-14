namespace VibeCoding.Api.Models.Responses;

public class HealthResponse
{
    public string Status { get; init; } = string.Empty;
    public DateTime CheckedAt { get; init; }
    public string Version { get; init; } = string.Empty;
}
