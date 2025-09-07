namespace OLMS.DTO
{
    public class NotificationDto
    {
        public int NotificationID { get; set; }   // Required for update
        public int UserId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
