using BookCRUD.Models;
namespace BookCRUD.Data
{
  

    public class Mockdata
    {
        public static List<Author> Authors = new List<Author>
        {
            new Author { Id = 1, Name = "J.K. Rowling" },
            new Author { Id = 2, Name = "George R.R. Martin" },
            new Author { Id = 3, Name = "Agatha Christie" },
            new Author { Id = 4, Name = "J.R.R. Tolkien" },
            new Author { Id = 5, Name = "Stephen King" }
        };

        public static List<Book> Books = new List<Book>
        {
            new Book { Id = 1, Title = "Harry Potter and the Sorcerer's Stone", AuthorId = 1 },
            new Book { Id = 2, Title = "Harry Potter and the Chamber of Secrets", AuthorId = 1 },
            new Book { Id = 3, Title = "A Game of Thrones", AuthorId = 2 },
            new Book { Id = 4, Title = "A Clash of Kings", AuthorId = 2 },
            new Book { Id = 5, Title = "Murder on the Orient Express", AuthorId = 3 },
            new Book { Id = 6, Title = "The ABC Murders", AuthorId = 3 },
            new Book { Id = 7, Title = "The Hobbit", AuthorId = 4 },
            new Book { Id = 8, Title = "The Lord of the Rings: The Fellowship of the Ring", AuthorId = 4 },
            new Book { Id = 9, Title = "The Shining", AuthorId = 5 },
            new Book { Id = 10, Title = "It", AuthorId = 5 }
        };
    }
}
