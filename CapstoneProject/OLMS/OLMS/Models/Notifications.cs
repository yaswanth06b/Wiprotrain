using System.ComponentModel.DataAnnotations;

namespace OLMS.Models
{
    public class Notifications
    {
        [Key]
        public int NotificationID { get; set; }

        [Required]
        public int UserId { get; set; }
        public Users User { get; set; }

        [Required]
        public string Message { get; set; }

        public bool IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
