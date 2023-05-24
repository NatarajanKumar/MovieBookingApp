using MovieBookingApp.API.Models;

namespace MovieBookingApp.API.Repository.Contract
{
    public interface IUserRepository
    {
        Task<List<Users>> GetAllUsers();
        Task<Users> GetUserByUserId(string userid);
        Task AddUser(Users user);
        Task UpdateUser(Users user);
        Task DeleteUser(string userid);
    }
}
