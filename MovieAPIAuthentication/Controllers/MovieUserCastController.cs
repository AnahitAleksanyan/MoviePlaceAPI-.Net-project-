using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPIAuthentication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPIAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieUserCastController : ControllerBase
    {

        private readonly MovieDBContext movieDBContext = new MovieDBContext();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieActorCast>>> GetMovieActorCasts()
        {
            return await movieDBContext.MovieActorCasts.ToListAsync();
        }

        [HttpPost]
        public string PostMovieUserCast(MovieUserCast movieUserCast)
        {
            try
            {
                movieDBContext.MovieUserCasts.Add(movieUserCast);
                movieDBContext.SaveChanges();
                return JsonConvert.SerializeObject("Movie user cast is successfully saved.");
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject("Wrong data");
            }
        }

        [HttpGet("{id}")]
        public string GetMovieUserCast(string id)
        {
            var b = movieDBContext.MovieUserCasts;
            var a= JsonConvert.SerializeObject(movieDBContext.MovieUserCasts.
                Where(mu => mu.UserId.Equals(id)).
                Join(
                movieDBContext.Movies,
                mu => mu.MovieId,
                m => m.Id,
                (mu, m) => new
                {
                    id = m.Id,
                    name = m.Name,
                    imageURL=m.ImageURL,
                    movieUserCasts=mu
                }));
            return a;
        }

        [HttpDelete("{id}")]
        public string DeleteMovieUserCast(int id)
        {
            var movieActorCast = movieDBContext.MovieUserCasts.Where(mu => mu.Id == id).FirstOrDefault();
            if (movieActorCast == null)
            {
                return "Not found";
            }

            movieDBContext.MovieUserCasts.Remove(movieActorCast);
            movieDBContext.SaveChangesAsync();

            return "Favorite movie was been deleted.";
        }
    }
}
