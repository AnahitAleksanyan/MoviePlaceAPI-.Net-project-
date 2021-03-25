
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviePlaceAPI.Models;

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
        public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
        {
            return  await movieDBContext.Actors.ToListAsync();
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
        public async Task<ActionResult<Actor>> PostActor(Actor actor)
        {
            movieDBContext.Actors.Add(actor);
            await movieDBContext.SaveChangesAsync();

            return CreatedAtAction("GetActor", new { id = actor.Id }, actor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Actor>> DeleteActor(int id)
        {
            var actor = await movieDBContext.Actors.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }

            movieDBContext.Actors.Remove(actor);
            await movieDBContext.SaveChangesAsync();

            return actor;
        }

        private bool ActorExist(int id)
        {
            return movieDBContext.Actors.Any(a => a.Id == id);
        }
    }
}

