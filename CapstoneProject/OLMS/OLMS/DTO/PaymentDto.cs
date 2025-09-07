namespace OLMS.DTO
{
    public class PaymentDto
    {
        public int PaymentID { get; set; }     // Required for update
        public int UserId { get; set; }
        public int CourseID { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
