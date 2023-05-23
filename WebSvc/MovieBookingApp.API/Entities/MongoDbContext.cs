using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieBookingApp.API.Models;

namespace MovieBookingApp.API.Entities
{
    public class MongoDbContext:IMongoDbContext
    {
        private readonly IMongoDatabase _database;
        public MongoDbContext(IOptions<DBConfiguration> options) 
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _database = client.GetDatabase(options.Value.DatabaseName);
        }
        public IMongoCollection<Movie> movies =>_database.GetCollection<Movie>("movies"); 
        public IMongoCollection<Users> users => _database.GetCollection<Users>("users");
        public IMongoCollection<Ticket> tickets => _database.GetCollection<Ticket>("tickets");
    }
}
