using MongoDB.Driver;
using MovieBookingApp.API.Entities;
using MovieBookingApp.API.Models;
using MovieBookingApp.API.Repository.Contract;

namespace MovieBookingApp.API.Repository.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMongoDbContext _dbContext;
        public MovieRepository(IMongoDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<List<Movie>> GetAllMovies()
        {
            return await _dbContext.movies.Find(_ => true).ToListAsync();
        }
        public async Task<Movie> GetMovieById(string moviename, string thetrename) 
        {
            var movie_filter = Builders<Movie>.Filter.Eq(m => m.MovieName,moviename) & Builders<Movie>.Filter.Eq(m => m.TheatreName,thetrename); 
            return await _dbContext.movies.Find(movie_filter).FirstOrDefaultAsync();
        }
        public async Task AddMovie(Movie movies)
        {
            await _dbContext.movies.InsertOneAsync(movies);
        }
        public async Task UpdateMovie(Movie movies)
        {
            var movie_filter = Builders<Movie>.Filter.Eq(m => m.MovieName, movies.MovieName) & Builders<Movie>.Filter.Eq(m => m.TheatreName, movies.TheatreName);
            await _dbContext.movies.ReplaceOneAsync(movie_filter, movies);
        }
        public async Task DeleteMovie(string moviename, string thetrename)
        {
            var movie_filter = Builders<Movie>.Filter.Eq(m => m.MovieName, moviename) & Builders<Movie>.Filter.Eq(m => m.TheatreName, thetrename);
            await _dbContext.movies.DeleteOneAsync(movie_filter);
        }
    }
}
