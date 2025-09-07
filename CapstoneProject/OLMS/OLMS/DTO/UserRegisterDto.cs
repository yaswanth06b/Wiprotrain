namespace OLMS.DTO
{
    public class UserRegisterDto
    {

            public string FullName { get; set; }

            public string Email { get; set; }

            public string Password { get; set; }

            public string Role { get; set; } // "Admin", "Instructor", "Student"
        }
    }

