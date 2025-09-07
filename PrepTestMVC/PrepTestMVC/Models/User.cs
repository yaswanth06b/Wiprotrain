using System.ComponentModel.DataAnnotations;

namespace PrepTestMVC.Models
{
    public class User
    {

        [Key]
        public int userid { get; set; }
        public string username { get; set; }
        public string passwordhash { get; set; }
    }
}
