using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookCRUD.Models;
using BookCRUD.Data;

namespace BookCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
       
            [HttpGet("book")]
            public IActionResult GetBooks()
            {
                var books = Data.Mockdata.Books;
                return Ok(books);
            }

            [HttpGet("book/{id}")]
            public IActionResult GetBook(int id)
            {
                var book = Data.Mockdata.Books.FirstOrDefault(b => b.Id == id);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }

            [HttpPost("book/create")]
            public IActionResult CreateBook([FromBody] Book book)
            {
                if (book == null || string.IsNullOrEmpty(book.Title) || book.AuthorId <= 0)
                {
                    return BadRequest("Invalid book data.");
                }
                var newId = Data.Mockdata.Books.Max(b => b.Id) + 1;
                book.Id = newId;
                Data.Mockdata.Books.Add(book);
                return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
            }

            [HttpPut("book/{id}")]
            public IActionResult UpdateBook(int id, [FromBody] UpdateBook updatedBook)
            {
                var existingBook = Data.Mockdata.Books.FirstOrDefault(b => b.Id == id);
                if (existingBook == null)
                {
                    return NotFound();
                }
                if (existingBook == null || string.IsNullOrEmpty(existingBook.Title) || existingBook.AuthorId <= 0)
                {
                    return BadRequest("Invalid book data.");
                }
                existingBook.Title = updatedBook.Title;
                existingBook.AuthorId = updatedBook.AuthorId;
                return Ok(existingBook);
            }

            [HttpDelete("book/{id}")]
            public IActionResult DeleteBook(int id)
            {
                var book = Data.Mockdata.Books.FirstOrDefault(b => b.Id == id);
                if (book == null)
                    return NotFound();
                Data.Mockdata.Books.Remove(book);
                return Ok(new { Message = "Book Deleted", id });
            }
        }
    }



