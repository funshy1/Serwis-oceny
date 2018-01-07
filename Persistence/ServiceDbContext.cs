using Microsoft.EntityFrameworkCore;
using projekt.Models;

namespace projekt.Persistence
{
    public class ServiceDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }

        public ServiceDbContext(DbContextOptions<ServiceDbContext> options): base(options)
        {
            
        }
    }
}