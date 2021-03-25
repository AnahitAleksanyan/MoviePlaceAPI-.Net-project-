using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPIAuthentication.Models;
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
    public class MovieActorCastController : ControllerBase
    {
        private readonly MovieDBContext movieDBContext = new MovieDBContext();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieActorCast>>> GetMovieActorCasts()
        {
            return  await movieDBContext.MovieActorCasts.ToListAsync();
        }

        [HttpGet("{id}")]
        public string GetMovieActorCast(int id)
        {
            return JsonConvert.SerializeObject(movieDBContext.MovieActorCasts.
                Where(ma => ma.MovieId == id).
                Join(
                movieDBContext.Actors,
                ma => ma.ActorId,
                a => a.Id,
                (ma, a) => new
                {
                    actor = a
                }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieActorCast(int id, MovieActorCast movieActorCast)
        {
            if (id != movieActorCast.Id)
            {
                return BadRequest();
            }

            movieDBContext.Entry(movieActorCast).State = EntityState.Modified;

            try
            {
                await movieDBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieActorCastExist(id))
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
        public string PostMovieActorCast(MovieActorCast movieActorCast)
        {
            try
            {
                movieDBContext.MovieActorCasts.Add(movieActorCast);
                movieDBContext.SaveChanges();
                return JsonConvert.SerializeObject("Movie is successfully saved.");
            }
            catch(Exception e)
            {
                return JsonConvert.SerializeObject("Wrong data");
            }

            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieActorCast>> DeleteMovieActorCast(int id)
        {
            var movieActorCast = await movieDBContext.MovieActorCasts.FindAsync(id);
            if (movieActorCast == null)
            {
                return NotFound();
            }

            movieDBContext.MovieActorCasts.Remove(movieActorCast);
            await movieDBContext.SaveChangesAsync();

            return movieActorCast;
        }


        private bool MovieActorCastExist(int id)
        {
            return movieDBContext.MovieActorCasts.Any(ma => ma.Id == id);
        }
    }
}

