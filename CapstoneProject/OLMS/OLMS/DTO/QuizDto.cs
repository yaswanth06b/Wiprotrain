namespace OLMS.DTO
{
    public class QuizDto
    {
        public int QuizID { get; set; }    // Required for update
        public int CourseID { get; set; }
        public string Title { get; set; }
    }
}
