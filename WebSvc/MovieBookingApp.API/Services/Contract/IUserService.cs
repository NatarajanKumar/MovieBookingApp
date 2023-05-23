using MovieBookingApp.API.Models;

namespace MovieBookingApp.API.Services.Contract
{
    public interface IUserService
    {
        Task<List<Users>> GetAllUsers();
        Task<Users> GetUserByUserId(string userid);
        Task AddUser(Users user);
        Task UpdateUser(Users user);
        Task DeleteUser(string userid);
    }
}
