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
    public class SubmissionsController : ControllerBase
    {
        private readonly OlmsDbContext _context;

        public SubmissionsController(OlmsDbContext context)
        {
            _context = context;
        }

        // GET: api/Submissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Submissions>>> GetSubmissions()
        {
            return await _context.Submissions.ToListAsync();
        }

        // GET: api/Submissions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Submissions>> GetSubmissions(int id)
        {
            var submissions = await _context.Submissions.FindAsync(id);

            if (submissions == null)
            {
                return NotFound();
            }

            return submissions;
        }

        // PUT: api/Submissions/5
        [HttpPost]
        public async Task<ActionResult<SubmissionDto>> CreateSubmission(SubmissionDto dto)
        {
            var userExists = await _context.users.AnyAsync(u => u.UserId == dto.UserId);
            var assignmentExists = await _context.Assignments.AnyAsync(a => a.AssignmentID == dto.AssignmentID);

            if (!userExists || !assignmentExists)
                return BadRequest("Invalid UserID or AssignmentID.");

            var submission = new Submissions
            {
                AssignmentID = dto.AssignmentID,
                UserId = dto.UserId,
                FileUrl =dto.FileUrl,
                Grade = dto.Grade,
                SubmittedAt = dto.SubmittedAt
            };

            _context.Submissions.Add(submission);
            await _context.SaveChangesAsync();

            dto.SubmissionID = submission.SubmissionID;
            return CreatedAtAction(nameof(GetSubmissions), new { id = submission.SubmissionID }, dto);
        }

        // PUT: api/submission/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubmission(int id, SubmissionDto dto)
        {
            if (id != dto.SubmissionID) return BadRequest("Submission ID mismatch.");

            var submission = await _context.Submissions.FindAsync(id);
            if (submission == null) return NotFound();

            
            submission.Grade = dto.Grade;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Submissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubmissions(int id)
        {
            var submissions = await _context.Submissions.FindAsync(id);
            if (submissions == null)
            {
                return NotFound();
            }

            _context.Submissions.Remove(submissions);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubmissionsExists(int id)
        {
            return _context.Submissions.Any(e => e.SubmissionID == id);
        }
    }
}
