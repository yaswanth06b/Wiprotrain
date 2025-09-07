using OLMS.Models;
using System.ComponentModel.DataAnnotations;

namespace OLMS.Models
{
    public class Courses
    {
        [Key]
        public int CourseID { get; set; }

        
        public string Title { get; set; }

       
        public string Description { get; set; }

        public string Category { get; set; }
        public string Difficulty { get; set; }

        [Required]
        public int? InstructorID { get; set; }
        public Instructors Instructor { get; set; }

        // Navigation
        public ICollection<Enrolments> Enrollments { get; set; }
        public ICollection<Assignments> Assignments { get; set; }
        public ICollection<Quizzes> Quizzes { get; set; }
    }
}
