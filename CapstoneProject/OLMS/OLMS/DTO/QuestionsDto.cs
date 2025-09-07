namespace OLMS.DTO
{
    public class QuestionsDto
    {
        public int Id { get; set; }    // Required for update
        public int QuizID { get; set; }
        public string QuestionText { get; set; }
        public string Options { get; set; }       // Could be JSON string or comma-separated
        public string CorrectAnswer { get; set; }
    }
}
