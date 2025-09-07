using System.ComponentModel.DataAnnotations;

namespace OLMS.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

       
        public string? FullName { get; set; }

        
        public string Email { get; set; }

        public string Role { get; set; }


        public string PasswordHash { get; set; }

        // Navigation
        public ICollection<Enrolments> Enrollments { get; set; }
        public ICollection<Submissions> Submissions { get; set; }
        public ICollection<Notifications> Notifications { get; set; }
        public ICollection<Payments> Payments { get; set; }
    }
}
