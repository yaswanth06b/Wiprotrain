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
    public class QuestionsController : ControllerBase
    {
        private readonly OlmsDbContext _context;

        public QuestionsController(OlmsDbContext context)
        {
            _context = context;
        }

        // GET: api/Questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Questions>>> GetQuestions()
        {
            return await _context.Questions.ToListAsync();
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Questions>> GetQuestions(int id)
        {
            var questions = await _context.Questions.FindAsync(id);

            if (questions == null)
            {
                return NotFound();
            }

            return questions;
        }

        // PUT: api/Questions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestionsDto>> CreateQuestion(QuestionsDto dto)
        {
            var quizExists = await _context.Quizzes.AnyAsync(q => q.QuizID == dto.QuizID);
            if (!quizExists) return BadRequest("Invalid QuizID.");

            var question = new Questions
            {
                QuizID = dto.QuizID,
                QuestionText = dto.QuestionText,
                Options = dto.Options,
                CorrectAnswer = dto.CorrectAnswer
            };

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            dto.Id = question.Id;
            return CreatedAtAction(nameof(GetQuestions), new { id = question.Id }, dto);
        }

        // PUT: api/question/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, QuestionsDto dto)
        {
            if (id != dto.Id) return BadRequest("Question ID mismatch.");

            var question = await _context.Questions.FindAsync(id);
            if (question == null) return NotFound();

            question.QuestionText = dto.QuestionText;
            question.Options = dto.Options;
            question.CorrectAnswer = dto.CorrectAnswer;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestions(int id)
        {
            var questions = await _context.Questions.FindAsync(id);
            if (questions == null)
            {
                return NotFound();
            }

            _context.Questions.Remove(questions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionsExists(int id)
        {
            return _context.Questions.Any(e => e.Id == id);
        }
    }
}
