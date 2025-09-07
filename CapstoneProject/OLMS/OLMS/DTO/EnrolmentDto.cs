namespace OLMS.DTO

{
    public class EnrolmentDto
    {
        public int EnrollmentID { get; set; }   // for update
        public int UserID { get; set; }         // FK to Student
        public int CourseID { get; set; }       // FK to Course
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
    }
}
