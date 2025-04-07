

namespace TeleHealthService.Model
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid StaffId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime ScheduledTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; } // Scheduled, Completed, Cancelled
        public string VideoRoomName { get; set; }

    }
}
