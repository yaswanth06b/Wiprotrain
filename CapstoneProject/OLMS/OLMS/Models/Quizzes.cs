using System.ComponentModel.DataAnnotations;

namespace OLMS.Models
{
    public class Quizzes
    {
        [Key]
        public int QuizID { get; set; }

        [Required]
        public int CourseID { get; set; }
        public Courses Course { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        // Navigation
        public ICollection<Questions> Questions { get; set; }
    }
}
