using MovieBookingApp.API.Models;

namespace MovieBookingApp.API.Services.Contract
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetAllTicket();
        Task<Ticket> GetTicketByUserId(string Ticketid);
        Task AddTicket(Ticket ticket);
        Task UpdateTicket(Ticket ticket);
        Task DeleteTicket(string Ticketid);
    }
}
