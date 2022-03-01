using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.DbContextConfiguration
{
    public static class DeliveryDbContextConfiguration
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                services.AddDbContext<DeliveryContext>(options => options.UseSqlServer(configuration.GetConnectionString("Delivery_Connection_String")));
            }
            else
            {
                services.AddDbContext<DeliveryContext>(options => options.UseSqlServer(configuration["Delivery_Connection_String"]));
            }


            return services;
        }
    }
}
