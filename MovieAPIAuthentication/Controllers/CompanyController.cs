
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
    public class CompanyController : ControllerBase
    {
        private readonly MovieDBContext movieDBContext = new MovieDBContext();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            return  await movieDBContext.Companies.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await movieDBContext.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            movieDBContext.Entry(company).State = EntityState.Modified;

            try
            {
                await movieDBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExist(id))
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
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            movieDBContext.Companies.Add(company);
            await movieDBContext.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }

        [HttpDelete("{id}")]
        public string DeleteCompany(int id)
        {
            var company = movieDBContext.Companies.Find(id);

            if (company == null)
            {
                return "Company not found";
            }
            var movie = movieDBContext.Movies.Where(m => m.CompanyId == id).FirstOrDefault();
            if (movie == null)
            {
                movieDBContext.Companies.Remove(company);
                movieDBContext.SaveChanges();
                return "Company was deleted";
            }
            else
            {
                return "The company cannot be deleted because it is used";
            }
        }

        private bool CompanyExist(int id)
        {
            return movieDBContext.Companies.Any(a => a.Id == id);
        }
    }
}

