
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPIAuthentication.Models;
using MoviePlaceAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePlaceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MovieDBContext movieDBContext = new MovieDBContext();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return  await movieDBContext.Categories.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await movieDBContext.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            movieDBContext.Entry(category).State = EntityState.Modified;

            try
            {
                await movieDBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExist(id))
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
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            movieDBContext.Categories.Add(category);
            await movieDBContext.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        [HttpDelete("{id}")]
        public string DeleteCategory(int id)
        {
            var category = movieDBContext.Categories.Find(id);
           
            if (category == null)
            {
                return "Category not found";
            }
            var movie = movieDBContext.Movies.Where(m => m.CategoryId == id).FirstOrDefault();
            if (movie == null)
            {
                movieDBContext.Categories.Remove(category);
                movieDBContext.SaveChanges();
                return "Category was deleted";
            }
            else {
                return "The category cannot be deleted because it is used";
            }
       
        }

        private bool CategoryExist(int id)
        {
            return movieDBContext.Categories.Any(a => a.Id == id);
        }
    }
}

