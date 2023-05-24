using MovieBookingApp.API.Models;

namespace MovieBookingApp.API.Services.Contract
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(string moviename, string thetrename);
        Task AddMovie(Movie movies);
        Task UpdateMovie(Movie movies);
        Task DeleteMovie(string moviename, string thetrename);
    }
}
