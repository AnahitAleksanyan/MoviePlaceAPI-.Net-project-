
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPIAuthentication.Models;
using MoviePlaceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePlaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly MovieDBContext movieDBContext = new MovieDBContext();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return  await movieDBContext.Countries.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await movieDBContext.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            movieDBContext.Entry(country).State = EntityState.Modified;

            try
            {
                await movieDBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExist(id))
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
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            movieDBContext.Countries.Add(country);
            await movieDBContext.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Country>> DeleteCountry(int id)
        {
            var country = await movieDBContext.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            movieDBContext.Countries.Remove(country);
            await movieDBContext.SaveChangesAsync();

            return country;
        }

        private bool CountryExist(int id)
        {
            return movieDBContext.Countries.Any(c => c.Id == id);
        }
    }
}

