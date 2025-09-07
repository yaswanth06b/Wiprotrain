using System.ComponentModel.DataAnnotations;

namespace PrepTest3.Models
{
    public class Admin
    {
        [Key]
        public int adminid { get; set; }


        public string username { get; set; }
        public string passwordhash { get; set; }
        
    }

}
