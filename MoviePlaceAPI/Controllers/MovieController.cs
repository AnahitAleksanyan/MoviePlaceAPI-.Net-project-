
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePlaceAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePlaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieDBContext movieDBContext = new MovieDBContext();

        [HttpGet]
        public string GetMovies()
        {
            return JsonConvert.SerializeObject(movieDBContext.Movies.ToList());
        }

        [HttpGet("{id}")]
        public  string GetMovie(int id)
        {
            var movie = movieDBContext.Movies.Find(id);

            if (movie == null)
            {
                return "Not found";
            }

            return JsonConvert.SerializeObject(movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            movieDBContext.Entry(movie).State = EntityState.Modified;

            try
            {
                await movieDBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            movieDBContext.Movies.Add(movie);
            await movieDBContext.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id)
        {
            var movie = await movieDBContext.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            movieDBContext.Movies.Remove(movie);
            await movieDBContext.SaveChangesAsync();

            return movie;
        }

        private bool MovieExist(int id)
        {
            return movieDBContext.Movies.Any(m => m.Id == id);
        }
    }
}
