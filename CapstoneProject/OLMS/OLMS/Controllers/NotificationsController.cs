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
    public class NotificationsController : ControllerBase
    {
        private readonly OlmsDbContext _context;

        public NotificationsController(OlmsDbContext context)
        {
            _context = context;
        }

        // GET: api/Notifications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notifications>>> GetNotifications()
        {
            return await _context.Notifications.ToListAsync();
        }

        // GET: api/Notifications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notifications>> GetNotifications(int id)
        {
            var notifications = await _context.Notifications.FindAsync(id);

            if (notifications == null)
            {
                return NotFound();
            }

            return notifications;
        }

        // POST: api/notification
        [HttpPost]
        public async Task<ActionResult<NotificationDto>> CreateNotification(NotificationDto dto)
        {
            var userExists = await _context.users.AnyAsync(u => u.UserId == dto.UserId);
            if (!userExists)
                return BadRequest("Invalid UserId.");

            var notification = new Notifications
            {
                UserId = dto.UserId,
                Message = dto.Message,
                IsRead = dto.IsRead,
                CreatedAt = dto.CreatedAt
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            dto.NotificationID = notification.NotificationID;
            return CreatedAtAction(nameof(GetNotifications), new { id = notification.NotificationID }, dto);
        }

        // PUT: api/notification/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotification(int id, NotificationDto dto)
        {
            if (id != dto.NotificationID)
                return BadRequest("Notification ID mismatch.");

            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
                return NotFound();

            notification.Message = dto.Message;
            notification.IsRead = dto.IsRead;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Notifications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotifications(int id)
        {
            var notifications = await _context.Notifications.FindAsync(id);
            if (notifications == null)
            {
                return NotFound();
            }

            _context.Notifications.Remove(notifications);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotificationsExists(int id)
        {
            return _context.Notifications.Any(e => e.NotificationID == id);
        }
    }
}
