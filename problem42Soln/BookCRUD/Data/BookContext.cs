using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BookCRUD.Models;

namespace BookCRUD.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
