using OLMS.Models;
using System.ComponentModel.DataAnnotations;

namespace OLMS.Models
{
    public class Assignments
    {
        [Key]
        public int AssignmentID { get; set; }

        [Required]
        public int CourseID { get; set; }
        public Courses Course { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        // Navigation
        public ICollection<Submissions> Submissions { get; set; }
    }
}