using MongoDB.Driver;
using MovieBookingApp.API.Entities;
using MovieBookingApp.API.Models;
using MovieBookingApp.API.Repository.Contract;

namespace MovieBookingApp.API.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDbContext _dbContext;
        public UserRepository(IMongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Users>> GetAllUsers()
        {
            return await _dbContext.users.Find(_ => true).ToListAsync();
        }
        public async Task<Users> GetUserByUserId(string userid) 
        {
            var user_filter = Builders<Users>.Filter.Eq(u => u.LoginID, userid);
            return await _dbContext.users.Find(user_filter).FirstOrDefaultAsync();
        }
        public async Task AddUser(Users user)
        {
            await _dbContext.users.InsertOneAsync(user);
        }
        public async Task UpdateUser(Users user)
        {
            var user_filter = Builders<Users>.Filter.Eq(u => u.LoginID, user.LoginID);
            await _dbContext.users.ReplaceOneAsync(user_filter, user);
        }
        public async Task DeleteUser(string userid)
        {
            var user_filter = Builders<Users>.Filter.Eq(u => u.LoginID, userid);
            await _dbContext.users.DeleteOneAsync(user_filter);
        }
    }
}
