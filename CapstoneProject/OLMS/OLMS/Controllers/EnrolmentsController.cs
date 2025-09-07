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
    public class EnrolmentsController : ControllerBase
    {
        private readonly OlmsDbContext _context;

        public EnrolmentsController(OlmsDbContext context)
        {
            _context = context;
        }

        // GET: api/Enrolments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enrolments>>> GetEnrollments()
        {
            return await _context.Enrollments.ToListAsync();
        }

        // GET: api/Enrolments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Enrolments>> GetEnrolments(int id)
        {
            var enrolments = await _context.Enrollments.FindAsync(id);

            if (enrolments == null)
            {
                return NotFound();
            }

            return enrolments;
        }

        [HttpPost]
        public async Task<ActionResult<EnrolmentDto>> CreateEnrolment(EnrolmentDto dto)
        {
            // check user and course exist
            var userExists = await _context.users.AnyAsync(u => u.UserId == dto.UserID);
            var courseExists = await _context.Courses.AnyAsync(c => c.CourseID == dto.CourseID);

            if (!userExists || !courseExists)
                return BadRequest("Invalid UserID or CourseID.");

            var enrolment = new Enrolments
            {
                UserID = dto.UserID,
                CourseID = dto.CourseID,
                EnrollmentDate = dto.EnrollmentDate
            };

            _context.Enrollments.Add(enrolment);
            await _context.SaveChangesAsync();

            dto.EnrollmentID = enrolment.EnrollmentID;
            return CreatedAtAction(nameof(GetEnrollments), new { id = enrolment.EnrollmentID }, dto);
        }

        // PUT: api/enrolment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnrolment(int id, EnrolmentDto dto)
        {
            if (id != dto.EnrollmentID)
                return BadRequest("Enrollment ID mismatch.");

            var enrolment = await _context.Enrollments.FindAsync(id);
            if (enrolment == null)
                return NotFound();

            enrolment.UserID = dto.UserID;
            enrolment.CourseID = dto.CourseID;
            enrolment.EnrollmentDate = dto.EnrollmentDate;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Enrolments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnrolments(int id)
        {
            var enrolments = await _context.Enrollments.FindAsync(id);
            if (enrolments == null)
            {
                return NotFound();
            }

            _context.Enrollments.Remove(enrolments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnrolmentsExists(int id)
        {
            return _context.Enrollments.Any(e => e.EnrollmentID == id);
        }
    }
}
