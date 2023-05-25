using Amazon.Auth.AccessControlPolicy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MovieBookingApp.API.Models;
using MovieBookingApp.API.Services.Contract;
using System.Net.Sockets;

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
            if(!ObjectId.TryParse(ticketId,out var objectId))
            {
                return BadRequest();
            }
            var tickets = await _ticketService.GetTicketByUserId(objectId);
            if (tickets == null)
            {
                return NotFound();
            }
            return Ok(tickets);
        }
        [HttpPost]
        //[Authorize(Policy = "Admin")]
        public async Task<ActionResult> AddTicket(Ticket ticket)
        {
            if(ModelState.IsValid)
            {
                await _ticketService.AddTicket(ticket);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("{ticketId}")]
        //[Authorize(Policy = "Admin")]
        public async Task<ActionResult> UpdateTicket(string ticketId, Ticket ticket)
        {
            if(!ObjectId.TryParse(ticketId, out var objectId) || objectId != ticket.TicketID)
            {
                return BadRequest();
            }
            await _ticketService.UpdateTicket(ticket);
            return Ok();
        }
        [HttpDelete("{ticketId}")]
        //[Authorize(Policy = "Admin")]
        public async Task<ActionResult> DeleteTicket(string ticketId)
        {
            if (!ObjectId.TryParse(ticketId, out var objectId))
            {
                return BadRequest();
            }
            await _ticketService.DeleteTicket(objectId);
            return Ok();
        }
    }
}
