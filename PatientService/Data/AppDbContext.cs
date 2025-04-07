using Microsoft.EntityFrameworkCore;
using PatientService.Entities;

namespace PatientService.Entities
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options )
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var patients = new List<Patient>
            {
                new Patient { Id = "p1", Name = "Alice Johnson", Email = "alice@example.com", Password = "pass1234" },
                new Patient { Id = "p2", Name = "Bob Smith", Email = "bob@example.com", Password = "pass5678" }
            };

            patients.ForEach(patient =>
            {
                modelBuilder.Entity<Patient>().HasData(patient);
            });
        }

        public DbSet<Patient> Patients { get; set; }
    }
}
