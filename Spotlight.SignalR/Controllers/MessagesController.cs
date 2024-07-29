using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Spotlight.SignalR.DAL;
using Spotlight.SignalR.Dtos;
using Spotlight.SignalR.Entities;
using Spotlight.SignalR.SignalR;

namespace Spotlight.SignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
       

        private readonly IHubContext<ChatHub> _hubContext;
        private readonly ApplicationDbContext _context;

        public MessagesController(IHubContext<ChatHub> hubContext, ApplicationDbContext context)
        {
            _hubContext = hubContext;
            _context = context;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] MessageDto messageDto)
        {
            var message = new Message
            {
                SenderId = messageDto.UserId,
                ReceiverId = messageDto.ReceiverId,
                Content = messageDto.Message,
                Timestamp = DateTime.UtcNow
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.User(messageDto.ReceiverId).SendAsync("ReceiveMessage", messageDto.UserId, messageDto.Message);
            return Ok(new { Status = "Message sent" });
        }

        [HttpGet("history/{user1}/{user2}")]
        public async Task<IActionResult> GetMessageHistory(string user1, string user2)
        {
            var messages = await _context.Messages
                .Where(m => (m.SenderId == user1 && m.ReceiverId == user2) || (m.SenderId == user2 && m.ReceiverId == user1))
                .OrderBy(m => m.Timestamp)
                .ToListAsync();

            return Ok(messages);
        }
    }


}

