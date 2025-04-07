using Microsoft.EntityFrameworkCore;
using StaffService.Entities;

namespace StaffService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options )
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var staffs = new List<Staff>
            {
                new Staff { Id = "s1", Name = "Dr. Sarah Blake", Email = "sarah@example.com", Password = "staff123" },
                new Staff { Id = "s2", Name = "Dr. Mike Daniels", Email = "mike@example.com", Password = "staff456" }
            };

            staffs.ForEach(staff =>
            {
                modelBuilder.Entity<Staff>().HasData(staff);
            });
        }
        public DbSet<Staff> Staffs { get; set; }
    }
}
