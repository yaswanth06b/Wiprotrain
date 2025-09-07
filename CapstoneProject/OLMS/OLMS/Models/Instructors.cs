using System.ComponentModel.DataAnnotations;

namespace OLMS.Models
{
    public class Instructors
    {
        [Key]
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        // Navigation
        public ICollection<Courses> Courses { get; set; }
    }
}
