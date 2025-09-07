using System.ComponentModel.DataAnnotations;

namespace OLMS.Models
{
    public class Cred
    {
        
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}

