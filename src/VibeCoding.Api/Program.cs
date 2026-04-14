using VibeCoding.Api.Models.Responses;
using VibeCoding.Application.Interfaces;
using VibeCoding.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHealthChecks("/health");

app.MapGet("/api/health", (IHealthService healthService) =>
{
    var status = healthService.GetHealthStatus();
    var response = new HealthResponse
    {
        Status = status.Status,
        CheckedAt = status.CheckedAt,
        Version = status.Version
    };
    return Results.Ok(response);
})
.WithName("GetHealth")
.WithOpenApi();

app.Run();
