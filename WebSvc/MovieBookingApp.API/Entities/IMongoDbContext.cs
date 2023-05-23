using MongoDB.Driver;
using MovieBookingApp.API.Models;

namespace MovieBookingApp.API.Entities
{
    public interface IMongoDbContext
    {
        IMongoCollection<Movie> movies { get; }
        IMongoCollection<Users> users { get; }
        IMongoCollection<Ticket> tickets { get; }
    }
}
