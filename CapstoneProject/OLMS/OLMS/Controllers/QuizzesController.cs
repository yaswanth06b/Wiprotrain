using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OLMS.DTO;
using OLMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OLMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly OlmsDbContext _context;

        public QuizzesController(OlmsDbContext context)
        {
            _context = context;
        }

        // GET: api/Quizzes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quizzes>>> GetQuizzes()
        {
            return await _context.Quizzes.ToListAsync();
        }

        // GET: api/Quizzes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quizzes>> GetQuizzes(int id)
        {
            var quizzes = await _context.Quizzes.FindAsync(id);

            if (quizzes == null)
            {
                return NotFound();
            }

            return quizzes;
        }

        // PUT: api/Quizzes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuizDto>> CreateQuiz(QuizDto dto)
        {
            var courseExists = await _context.Courses.AnyAsync(c => c.CourseID == dto.CourseID);
            if (!courseExists) return BadRequest("Invalid CourseID.");

            var quiz = new Quizzes
            {
                CourseID = dto.CourseID,
                Title = dto.Title
            };

            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();

            dto.QuizID = quiz.QuizID;
            return CreatedAtAction(nameof(GetQuizzes), new { id = quiz.QuizID }, dto);
        }

        // PUT: api/quiz/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuiz(int id, QuizDto dto)
        {
            if (id != dto.QuizID) return BadRequest("Quiz ID mismatch.");

            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz == null) return NotFound();

            quiz.Title = dto.Title;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Quizzes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizzes(int id)
        {
            var quizzes = await _context.Quizzes.FindAsync(id);
            if (quizzes == null)
            {
                return NotFound();
            }

            _context.Quizzes.Remove(quizzes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuizzesExists(int id)
        {
            return _context.Quizzes.Any(e => e.QuizID == id);
        }
    }
}
