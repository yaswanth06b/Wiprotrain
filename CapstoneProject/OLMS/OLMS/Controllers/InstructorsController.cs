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
    [ApiController]
    [Route("api/[controller]")]
        public class InstructorsController : ControllerBase
        {
            private readonly OlmsDbContext _context;

            public InstructorsController(OlmsDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<IActionResult> GetInstructors() =>
                Ok(await _context.Instructors.ToListAsync());

            [HttpGet("{id}")]
            public async Task<IActionResult> GetInstructor(int id)
            {
                var instructor = await _context.Instructors.FindAsync(id);
                return instructor == null ? NotFound() : Ok(instructor);
            }

        // POST: api/instructor
        [HttpPost]
        public async Task<ActionResult<InstructorDto>> CreateInstructor(InstructorDto dto)
        {
            var instructor = new Instructors
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = dto.PasswordHash
            };

            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();

            dto.Id = instructor.Id; // return generated Id
            return CreatedAtAction(nameof(GetInstructor), new { id = instructor.Id }, dto);
        }

        // PUT: api/instructor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInstructor(int id, InstructorDto dto)
        {
            if (id != dto.Id)
                return BadRequest("Instructor ID mismatch.");

            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
                return NotFound();

            instructor.Name = dto.Name;
            instructor.Email = dto.Email;
            instructor.PasswordHash = dto.PasswordHash;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteInstructor(int id)
            {
                var instructor = await _context.Instructors.FindAsync(id);
                if (instructor == null) return NotFound();

                _context.Instructors.Remove(instructor);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
