using MongoDB.Driver;
using MovieBookingApp.API.Entities;
using MovieBookingApp.API.Models;
using MovieBookingApp.API.Repository.Contract;

namespace MovieBookingApp.API.Repository.Implementation
{
    public class TicketRepository : ITicketRepository
    {
        private readonly IMongoDbContext _dbContext;
        public TicketRepository(IMongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Ticket>> GetAllTicket()
        {
            return await _dbContext.tickets.Find(_ => true).ToListAsync();
        }
        public async Task<Ticket> GetTicketByUserId(string Ticketid)
        {
            var ticket_filter = Builders<Ticket>.Filter.Eq(t => t.TicketID, Ticketid);
            return await _dbContext.tickets.Find(ticket_filter).FirstOrDefaultAsync();
        }
        public async Task AddTicket(Ticket ticket)
        {
            await _dbContext.tickets.InsertOneAsync(ticket);
        }
        public async Task UpdateTicket(Ticket ticket)
        {
            var ticket_filter = Builders<Ticket>.Filter.Eq(t => t.TicketID, ticket.TicketID);
            await _dbContext.tickets.ReplaceOneAsync(ticket_filter, ticket);
        }
        public async Task DeleteTicket(string Ticketid)
        {
            var ticket_filter = Builders<Ticket>.Filter.Eq(t => t.TicketID, Ticketid);
            await _dbContext.tickets.DeleteOneAsync(ticket_filter);
        }
    }
}
