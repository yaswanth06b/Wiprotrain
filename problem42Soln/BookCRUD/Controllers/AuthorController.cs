using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookCRUD.Models;
using BookCRUD.Data;

namespace BookCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
            [HttpGet("author")]
            public IActionResult GetAuthor()
            {
                var authors = Data.Mockdata.Authors;
                return Ok(authors);
            }

            [HttpGet("author/{id}")]
            public IActionResult GetAuthor(int id)
            {
                var author = Data.Mockdata.Authors.FirstOrDefault(a => a.Id == id);
                if (author == null)
                {
                    return NotFound();
                }
                return Ok(author);
            }

            [HttpPost("author/{id}/books")]
            public IActionResult GetBooksByAuthor(int id)
            {
                var author = Data.Mockdata.Authors.FirstOrDefault(a => a.Id == id);
                if (author == null)
                {
                    return NotFound();
                }
                var books = Data.Mockdata.Books.Where(b => b.AuthorId == id).ToList();
                return Ok(books);
            }
        }
    }


