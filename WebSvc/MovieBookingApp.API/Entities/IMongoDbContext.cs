using MongoDB.Driver;
using MovieBookingApp.API.Models;

namespace MovieBookingApp.API.Entities
{
    public interface IMongoDbContext
    {
        //IMongoCollection<T> GetCollection<T>(string name);
        public IMongoCollection<Movie> movies();
        public IMongoCollection<Users> users();
        public IMongoCollection<Ticket> tickets()
    }
}
