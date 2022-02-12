using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DeliveryContext : IdentityDbContext
{

    public DeliveryContext(DbContextOptions options) : base(options) { }

}
