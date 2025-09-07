using System.ComponentModel.DataAnnotations;

namespace OLMS.Models
{
    public class Submissions
    {
        [Key]
        public int SubmissionID { get; set; }

        [Required]
        public int AssignmentID { get; set; }
        public Assignments Assignment { get; set; }

        [Required]
        public int UserId { get; set; }
        public Users User { get; set; }

        public string FileUrl { get; set; }
        public double? Grade { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
