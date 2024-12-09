using Application.Common.Interfaces;
using Common;
using MicrblogApp.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicrblogApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<ICurrentUserService, CurrentUserService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<IIdentityService, IdentityService>();
        return services;
    }
}