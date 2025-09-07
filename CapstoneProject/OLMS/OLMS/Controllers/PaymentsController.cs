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
    public class PaymentsController : ControllerBase
    {
        private readonly OlmsDbContext _context;

        public PaymentsController(OlmsDbContext context)
        {
            _context = context;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payments>>> GetPayments()
        {
            return await _context.Payments.ToListAsync();
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payments>> GetPayments(int id)
        {
            var payments = await _context.Payments.FindAsync(id);

            if (payments == null)
            {
                return NotFound();
            }

            return payments;
        }

        [HttpPost]
        public async Task<ActionResult<PaymentDto>> CreatePayment(PaymentDto dto)
        {
            var userExists = await _context.users.AnyAsync(u => u.UserId == dto.UserId);
            var courseExists = await _context.Courses.AnyAsync(c => c.CourseID == dto.CourseID);

            if (!userExists || !courseExists)
                return BadRequest("Invalid UserID or CourseID.");

            var payment = new Payments
            {
                UserId = dto.UserId,
                CourseID = dto.CourseID,
                Amount = dto.Amount,
                Status = dto.Status,
                CreatedAt = dto.CreatedAt
            };

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            dto.PaymentID = payment.PaymentID;
            return CreatedAtAction(nameof(GetPayments), new { id = payment.PaymentID }, dto);
        }

        // PUT: api/payment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, PaymentDto dto)
        {
            if (id != dto.PaymentID)
                return BadRequest("Payment ID mismatch.");

            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
                return NotFound();

            payment.Amount = dto.Amount;
            payment.Status = dto.Status;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayments(int id)
        {
            var payments = await _context.Payments.FindAsync(id);
            if (payments == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(payments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentsExists(int id)
        {
            return _context.Payments.Any(e => e.PaymentID == id);
        }
    }
}
