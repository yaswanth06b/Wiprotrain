using System.ComponentModel.DataAnnotations;

namespace OLMS.Models
{
    public class Payments
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public int UserId { get; set; }
        public Users User { get; set; }
        
        [Required]
        public int CourseID { get; set; }
        public Courses Course { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public string Status { get; set; } // Pending, Completed, Failed
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
