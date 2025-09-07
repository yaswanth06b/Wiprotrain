using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OLMS.Models
{
    public class Enrolments
    {
        [Key]
        public int EnrollmentID { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserID { get; set; }

        public Users User { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int CourseID { get; set; }

        public Courses Course { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
    }
}
