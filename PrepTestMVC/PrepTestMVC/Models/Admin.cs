using System.ComponentModel.DataAnnotations;

namespace PrepTestMVC.Models
{
    public class Admin
    {
        [Key]
        public int adminid { get; set; }


        public string username { get; set; }
        public string passwordhash { get; set; }
    }
}
