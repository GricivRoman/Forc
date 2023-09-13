using ForcWebApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForcWebApi.Infrastructure
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("ForcDB"));
        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Dish> Dish { get; set; }
        public DbSet<PhysicalActivityCatalog> PhysicalActivityCatalog { get; set; }
        public DbSet<Meal> Meal { get; set; }
    }
}
