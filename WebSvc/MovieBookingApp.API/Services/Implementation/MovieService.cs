using MongoDB.Driver;
using MovieBookingApp.API.Entities;
using MovieBookingApp.API.Models;
using MovieBookingApp.API.Repository.Contract;
using MovieBookingApp.API.Services.Contract;

namespace MovieBookingApp.API.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<List<Movie>> GetAllMovies()
        {
            return await _movieRepository.GetAllMovies();
        }
        public async Task<Movie> GetMovieById(string moviename)
        {
            return await _movieRepository.GetMovieById(moviename);
        }
        public async Task AddMovie(Movie movies)
        {
            await _movieRepository.AddMovie(movies);
        }
        public async Task UpdateMovie(Movie movies)
        {
            await _movieRepository.UpdateMovie(movies);
        }
        public async Task DeleteMovie(string moviename, string thetrename)
        {
            await _movieRepository.DeleteMovie(moviename, thetrename);
        }
    }
}
