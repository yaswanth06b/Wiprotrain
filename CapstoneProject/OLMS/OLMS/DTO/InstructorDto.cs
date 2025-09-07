namespace OLMS.DTO
{
    public class InstructorDto
    {
        public int Id { get; set; }          // For update/read
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
