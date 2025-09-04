using System.ComponentModel.DataAnnotations;

namespace BookCRUD.Models
{
    public class Book
    {
   
            [Key]
            public int Id { get; set; }
            public string? Title { get; set; }
            public int AuthorId { get; set; }

    }
}
