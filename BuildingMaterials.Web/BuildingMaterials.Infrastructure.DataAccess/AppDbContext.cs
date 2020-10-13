using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BuildingMaterials.Infrastructure.Domain.Orders.Entities;
using BuildingMaterials.Infrastructure.Domain.Users.Entities;

namespace BuildingMaterials.Infrastructure.DataAccess
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
