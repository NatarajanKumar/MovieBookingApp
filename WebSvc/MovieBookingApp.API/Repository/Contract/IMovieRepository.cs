using MovieBookingApp.API.Models;

namespace MovieBookingApp.API.Repository.Contract
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(string moviename);
        Task AddMovie(Movie movies);
        Task UpdateMovie(Movie movies);
        Task DeleteMovie(string moviename, string thetrename);
    }
}
