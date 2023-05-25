using MongoDB.Bson;
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
        public async Task<Ticket> GetTicketByUserId(ObjectId Ticketid)
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
            var update_tiket = Builders<Ticket>.Update
                .Set(u => u.MovieName, ticket.MovieName)
                .Set(u => u.TheatreName, ticket.TheatreName)
                .Set(u => u.NumberOfTickets, ticket.NumberOfTickets)
                .Set(u => u.SeatNumber, ticket.SeatNumber);
            await _dbContext.tickets.UpdateOneAsync(ticket_filter, update_tiket);
        }
        public async Task DeleteTicket(ObjectId Ticketid)
        {
            var ticket_filter = Builders<Ticket>.Filter.Eq(t => t.TicketID, Ticketid);
            await _dbContext.tickets.DeleteOneAsync(ticket_filter);
        }
    }
}
