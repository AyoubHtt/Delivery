using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure;

public class DeliveryContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{

    public DeliveryContext(DbContextOptions options) : base(options) { }

}
