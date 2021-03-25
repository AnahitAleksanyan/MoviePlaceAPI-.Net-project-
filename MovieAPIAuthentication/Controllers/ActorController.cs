
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPIAuthentication.Models;
using MovieAPIAuthentication.Utils;
using MoviePlaceAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePlaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly MovieDBContext movieDBContext = new MovieDBContext();

        [HttpGet]
        public string GetActors()
        {
            return JsonConvert.SerializeObject(movieDBContext.Actors.Join(
                movieDBContext.Countries,
                a=>a.CountryId,
                c=>c.Id,
                (a, c) => new 
                 {
                     id=a.Id,
                     name = a.Name,
                     surname=a.Surname,
                     dateOfBirth=a.DateOfBirth,
                     country=c,
                     countryId=c.Id,
                     movieActorCasts=a.MovieActorCasts

                }).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActor(int id)
        {
            var actor = await movieDBContext.Actors.FindAsync(id);

            if (actor == null)
            {
                return NotFound();
            }

            return actor;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutActor(int id, Actor actor)
        {
            if (id != actor.Id)
            {
                return BadRequest();
            }

            movieDBContext.Entry(actor).State = EntityState.Modified;

            try
            {
                await movieDBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActorExist(id))
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
        public string PostActor([FromBody] ActorForJson actorForJson)
        {
            try
            {
                Actor actor = ActorConverter.ConvertJsonActorToActor(actorForJson);
                movieDBContext.Actors.Add(actor);
                movieDBContext.SaveChangesAsync();
                return JsonConvert.SerializeObject("Actor is successfully saved.");
            }
            catch {
                return JsonConvert.SerializeObject("Wrong data");
            }

           
        }

        [HttpDelete("{id}")]
        public string DeleteActor(int id)
        {
            var actor = movieDBContext.Actors.Find(id);

            if (actor == null)
            {
                return "Actor not found";
            }
            var movieActor = movieDBContext.MovieActorCasts.Where(ma => ma.ActorId == id).FirstOrDefault();
            if (movieActor == null)
            {
                movieDBContext.Actors.Remove(actor);
                movieDBContext.SaveChanges();
                return "Actor was deleted";
            }
            else
            {
                return "The actor cannot be deleted because it is used";
            }
        }

        private bool ActorExist(int id)
        {
            return movieDBContext.Actors.Any(a => a.Id == id);
        }
    }
}

