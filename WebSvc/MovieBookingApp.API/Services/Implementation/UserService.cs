using MongoDB.Driver;
using MovieBookingApp.API.Entities;
using MovieBookingApp.API.Models;
using MovieBookingApp.API.Repository.Contract;
using MovieBookingApp.API.Services.Contract;

namespace MovieBookingApp.API.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<Users>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }
        public async Task<Users> GetUserByUserId(string userid)
        {
            return await _userRepository.GetUserByUserId(userid);
        }
        public async Task AddUser(Users user)
        {
            await _userRepository.AddUser(user);
        }
        public async Task UpdateUser(Users user)
        {
            await _userRepository.UpdateUser(user);
        }
        public async Task DeleteUser(string userid)
        {
            await _userRepository.DeleteUser(userid);
        }
    }
}
