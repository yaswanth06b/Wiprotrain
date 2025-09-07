using System.ComponentModel.DataAnnotations;

namespace OLMS.Models
{
    public class Admins
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(150)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
