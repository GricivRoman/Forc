using ForcWebApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ForcWebApi.Infrastructure
{
    public class DataContext : IdentityDbContext<User>
    {
        protected readonly IConfiguration _config;

        public DataContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_config.GetConnectionString("ForcDB"));
        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<PhysicalActivityCatalog> PhysicalActivityCatalog { get; set; }
        public DbSet<Meal> Meal { get; set; }
    }
}
