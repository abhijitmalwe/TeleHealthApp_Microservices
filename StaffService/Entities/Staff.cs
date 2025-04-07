using System.ComponentModel.DataAnnotations;

namespace StaffService.Entities
{
    public class Staff
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
