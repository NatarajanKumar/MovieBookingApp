using Amazon.Auth.AccessControlPolicy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieBookingApp.API.Models;
using MovieBookingApp.API.Services.Contract;

namespace MovieBookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Ticket>>> GetAllTickets()
        {
            var tickets = await _ticketService.GetAllTicket();
            return Ok(tickets);
        }
        [HttpGet("{ticketId}")]
        public async Task<ActionResult<Ticket>> GetTicketByName(string ticketId)
        {
            var tickets = await _ticketService.GetTicketByUserId(ticketId);
            if (tickets == null)
            {
                return NotFound();
            }
            return Ok(tickets);
        }
        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> AddTicket(Ticket ticket)
        {
            await _ticketService.AddTicket(ticket);
            return CreatedAtAction(nameof(GetTicketByName),
                new
                {
                    ticketId = ticket.TicketID
                }, ticket);
        }
        [HttpPut("{ticketId}")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> UpdateTicket(string ticketId, Ticket ticket)
        {
            if (ticketId != ticket.TicketID)
            {
                return BadRequest();
            }
            await _ticketService.UpdateTicket(ticket);
            return NoContent();
        }
        [HttpDelete("{ticketId}")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> DeleteTicket(string ticketId)
        {
            await _ticketService.DeleteTicket(ticketId);
            return NoContent();
        }
    }
}
