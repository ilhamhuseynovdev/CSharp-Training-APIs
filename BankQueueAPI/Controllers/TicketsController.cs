using BankQueueAPI.Data;
using BankQueueAPI.Models;
using BankQueueAPI.Utilities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BankQueueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly AppDbcontext _context;

        public TicketsController(AppDbcontext context)
        {
            _context = context;
        }

        [HttpPost("take/{serviceId}")]
        public async Task<IActionResult> TakeTicket(int serviceId)
        {
            var serviceType = await _context.ServiceTypes.FirstOrDefaultAsync(s => s.Id == serviceId);
            if (serviceType is null) return NotFound("Wrong Service type ID");

            var lastTicketNumber = await _context.Tickets
                .Where(t => t.ServiceTypeId == serviceId)
                .OrderByDescending(t=>t.TicketNumber)
                .Select(t => t.TicketNumber)
                .FirstOrDefaultAsync(); 

            lastTicketNumber ++;

            var ticket = new Ticket()
            {
                TicketNumber = lastTicketNumber,
                IssueTime = DateTime.UtcNow,
                Status = TicketStatus.Waiting,
                ServiceTypeId = serviceType.Id
            };


            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();


            return Ok($"Ticket №:{serviceType.Prefix}-{lastTicketNumber} ; Time:{DateTime.UtcNow}");
        }

        [HttpPut("call-next/{serviceTypeId}")]
        public async Task<IActionResult> CallNext(int serviceTypeId)
        {
            var oldestTicket = await _context.Tickets
                .Include(t=>t.ServiceType)
                .Where(t=>t.ServiceTypeId == serviceTypeId && t.Status == TicketStatus.Waiting)
                .OrderBy(t=>t.IssueTime)
                .FirstOrDefaultAsync();
            if (oldestTicket is null) return NotFound("There is no one in queue");

            //var serviceType = await _context.ServiceTypes
            //    .Where(s=>s.Id == oldestTicket.ServiceTypeId)
            //    .FirstOrDefaultAsync();


            oldestTicket.Status = TicketStatus.Serving;

            await _context.SaveChangesAsync();


            return Ok($"Ticket №:{oldestTicket.ServiceType.Prefix}-{oldestTicket.TicketNumber} ; Time:{DateTime.UtcNow}");
        }

        [HttpPut("complete/{ticketId}")]
        public async Task<IActionResult> CompleteTicket(int ticketId)
        {
            var ticket = await _context.Tickets .FirstOrDefaultAsync(t=>t.Id == ticketId);
            if (ticket is null) return NotFound("Ticket not founded");
            if (ticket.Status == TicketStatus.Completed) return BadRequest("Ticket already completed");

            ticket.Status = TicketStatus.Completed;

            await _context.SaveChangesAsync();

            return Ok("Completed");
        }
    }
}
