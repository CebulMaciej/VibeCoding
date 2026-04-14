using Microsoft.Extensions.DependencyInjection;
using VibeCoding.Application.Interfaces;
using VibeCoding.Infrastructure.Services;

namespace VibeCoding.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IHealthService, HealthService>();
        return services;
    }
}
