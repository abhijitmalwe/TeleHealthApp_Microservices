using AuthService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options )
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<User> users = new List<User>()
            {
                new User { UserId = 1, Name = "Jhon Statman", Address = "1420 St, New York, NY", Email = "jhonstatman@yop.com", Password = "Password@123" },
                new User { UserId = 2, Name = "Rechard T", Address = "1420 St, New York, NY", Email = "rechardt@yop.com", Password = "Password@123" },
                };

            users.ForEach(u =>
            {
                modelBuilder.Entity<User>().HasData(u);
            });          
           
        }

        public DbSet<User> Users { get; set; }

    }
}
