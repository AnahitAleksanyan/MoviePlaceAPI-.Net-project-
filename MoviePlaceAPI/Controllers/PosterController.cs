
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
    public class PosterController : ControllerBase
    {
        private readonly MovieDBContext movieDBContext = new MovieDBContext();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poster>>> GetPosters()
        {
            return  await movieDBContext.Posters.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Poster>> GetPoster(int id)
        {
            var poster = await movieDBContext.Posters.FindAsync(id);

            if (poster == null)
            {
                return NotFound();
            }

            return poster;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoster(int id, Poster poster)
        {
            if (id != poster.Id)
            {
                return BadRequest();
            }

            movieDBContext.Entry(poster).State = EntityState.Modified;

            try
            {
                await movieDBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosterExist(id))
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
        public async Task<ActionResult<Poster>> PostPoster(Poster poster)
        {
            movieDBContext.Posters.Add(poster);
            await movieDBContext.SaveChangesAsync();

            return CreatedAtAction("GetPoster", new { id = poster.Id }, poster);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Poster>> DeletePoster(int id)
        {
            var poster = await movieDBContext.Posters.FindAsync(id);
            if (poster == null)
            {
                return NotFound();
            }

            movieDBContext.Posters.Remove(poster);
            await movieDBContext.SaveChangesAsync();

            return poster;
        }

        private bool PosterExist(int id)
        {
            return movieDBContext.Posters.Any(a => a.Id == id);
        }
    }
}

