using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TeleHealthService.Model;

namespace TeleHealthService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options )
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Appointments
            var appointments = new List<Appointment>
            {
                new Appointment
                {
                    Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    PatientId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    StaffId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    ScheduledTime = DateTime.UtcNow.AddHours(1),
                    Duration = TimeSpan.FromMinutes(30),
                    Notes = "General Checkup",
                    Status = "Scheduled",
                    VideoRoomName = "room-abc123"
                },
                new Appointment
                {
                    Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    PatientId = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                    StaffId = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                    ScheduledTime = DateTime.UtcNow.AddHours(2),
                    Duration = TimeSpan.FromMinutes(45),
                    Notes = "Follow-up",
                    Status = "Scheduled",
                    VideoRoomName = "room-def456"
                }
            };

            modelBuilder.Entity<Appointment>().HasData(appointments);

            // Seed Notification Requests
            var notifications = new List<NotificationRequest>
            {
                new NotificationRequest
                {
                    Email = "patient1@example.com",
                    PhoneNumber = "1234567890",
                    Message = "Your appointment is scheduled.",
                    Type = "email"
                },
                new NotificationRequest
                {
                    Email = "staff1@example.com",
                    PhoneNumber = "9876543210",
                    Message = "You have an appointment.",
                    Type = "sms"
                }
            };

            modelBuilder.Entity<NotificationRequest>().HasData(notifications);

            // Seed Waiting Room Requests
            var waitingRooms = new List<WaitingRoomRequest>
            {
                new WaitingRoomRequest
                {
                    AppointmentId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    UserType = "Patient",
                    ConnectionId = "conn-patient1"
                },
                new WaitingRoomRequest
                {
                    AppointmentId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    UserType = "Staff",
                    ConnectionId = "conn-staff1"
                }
            };

            modelBuilder.Entity<WaitingRoomRequest>().HasData(waitingRooms);
        }


        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<NotificationRequest> NotificationRequest { get; set; }
             public DbSet<WaitingRoomRequest> WaitingRoomRequest { get; set; }
    }
}
