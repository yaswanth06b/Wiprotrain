namespace OLMS.DTO
{
    public class SubmissionDto
    {
        public int SubmissionID { get; set; }    // Required for update
        public int AssignmentID { get; set; }
        public int UserId { get; set; }
        public string FileUrl { get; set; }

        public double? Grade { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
