using System.ComponentModel.DataAnnotations;

namespace PrepTest3.Models
{
    public class User
    {
        [Key]
        public int userid { get; set; }
        public string username { get; set; }
        public string passwordhash { get; set; }
            
        }

    }

