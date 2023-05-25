using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieBookingApp.API.Models;
using MovieBookingApp.API.Services.Contract;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieBookingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService; 
        public MovieController(IMovieService movieService) 
        {
            _movieService = movieService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetAllMovies()
        {
            var movies = await _movieService.GetAllMovies();
            return Ok(movies);
        }
        [HttpGet("{movieName}")]
        public async Task<ActionResult<Movie>> GetMovieByName(string movieName)
        {
            var movie = await _movieService.GetMovieById(movieName);
            if(movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
        [HttpPost]
        //[Authorize(Policy ="Admin")]
        public async Task<ActionResult> AddMovie(Movie movies)
        {
            if(ModelState.IsValid)
            {
                await _movieService.AddMovie(movies);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("{movieName}")]
        //[Authorize(Policy = "Admin")]
        public async Task<ActionResult> UpdateMovie(string movieName, Movie movies)
        {
            if (movieName != movies.MovieName)
            {
                return BadRequest();
            }
            await _movieService.UpdateMovie(movies);
            return Ok();
        }
        [HttpDelete]
        //[Authorize(Policy = "Admin")]
        public async Task<ActionResult> DeleteMovie(string movieName, string thetrename)
        {
            await _movieService.DeleteMovie(movieName, thetrename);
            return Ok();
        }
    }
}
