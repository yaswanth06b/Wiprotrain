using System.ComponentModel.DataAnnotations;

namespace OLMS.Models
{
    public class Questions
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int QuizID { get; set; }
        public Quizzes Quiz { get; set; }

        [Required]
        public string QuestionText { get; set; }

        [Required]
        public string Options { get; set; } // store as JSON ["A","B","C","D"]

        [Required]
        public string CorrectAnswer { get; set; }
    }
}
