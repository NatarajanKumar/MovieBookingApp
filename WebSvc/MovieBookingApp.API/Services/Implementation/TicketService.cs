using MongoDB.Bson;
using MongoDB.Driver;
using MovieBookingApp.API.Entities;
using MovieBookingApp.API.Models;
using MovieBookingApp.API.Repository.Contract;
using MovieBookingApp.API.Services.Contract;

namespace MovieBookingApp.API.Services.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public async Task<List<Ticket>> GetAllTicket()
        {
            return await _ticketRepository.GetAllTicket();
        }
        public async Task<Ticket> GetTicketByUserId(ObjectId Ticketid)
        {
            return await _ticketRepository.GetTicketByUserId(Ticketid);
        }
        public async Task AddTicket(Ticket ticket)
        {
            await _ticketRepository.AddTicket(ticket);
        }
        public async Task UpdateTicket(Ticket ticket)
        {
            await _ticketRepository.UpdateTicket(ticket);
        }
        public async Task DeleteTicket(ObjectId Ticketid)
        {
            await _ticketRepository.DeleteTicket(Ticketid);
        }
    }
}
