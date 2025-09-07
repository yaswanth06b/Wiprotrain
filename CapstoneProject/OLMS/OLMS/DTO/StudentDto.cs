namespace OLMS.DTO
{
    public class StudentDto
    {
        public int UserId { get; set; }    // Required for update
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
       
    }
}
