using Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace API.Infrastructure.AuthConfiguration;

public static class IdentityConfiguration
{
    public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
    {
        services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<DeliveryContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}
