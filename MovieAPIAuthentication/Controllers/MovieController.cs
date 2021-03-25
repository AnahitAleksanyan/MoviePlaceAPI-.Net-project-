
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAPIAuthentication.Models;
using MovieAPIAuthentication.Utils;
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
        public string GetMovie(int id)
        {
            return JsonConvert.SerializeObject(movieDBContext.Movies.Where(m => m.Id == id).Join(
                movieDBContext.Countries,
                m => m.CountryId,
                c => c.Id,
                (m, c) => new
                {
                    id = m.Id,
                    name = m.Name,
                    description = m.Description,
                    createdDate = m.CreatedDate,
                    startDate = m.StartDate,
                    length = m.Length,
                    producerName = m.ProducerName,
                    budget = m.Budget,
                    movieActorCasts = m.MovieActorCasts,
                    rating = m.Rating,
                    countryId = c.Id,
                    country = c,
                    companyId = m.CompanyId,
                    company = m.Company,
                    categoryId = m.CategoryId,
                    category = m.Category,
                    imageURL = m.ImageURL
                }).Join(
                movieDBContext.Companies,
                m => m.companyId,
                c => c.Id,
                (m, c) => new
                {
                    id = m.id,
                    name = m.name,
                    description = m.description,
                    createdDate = m.createdDate,
                    startDate = m.startDate,
                    length = m.length,
                    producerName = m.producerName,
                    budget = m.budget,
                    movieActorCasts = m.movieActorCasts,
                    rating = m.rating,
                    countryId = m.countryId,
                    country = m.country,
                    categoryId = m.categoryId,
                    category = m.category,
                    companyId = c.Id,
                    company = c,
                    imageURL = m.imageURL
                }).Join(
                movieDBContext.Categories,
                m => m.categoryId,
                c => c.Id,
                (m, c) => new
                {
                    id = m.id,
                    name = m.name,
                    description = m.description,
                    createdDate = m.createdDate,
                    startDate = m.startDate,
                    length = m.length,
                    producerName = m.producerName,
                    budget = m.budget,
                    movieActorCasts = m.movieActorCasts,
                    rating = m.rating,
                    countryId = m.countryId,
                    country = m.country,
                    categoryId = c.Id,
                    category = c,
                    companyId = m.companyId,
                    company = m.company,
                    imageURL = m.imageURL
                }).FirstOrDefault());

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
        public string PostMovie(MovieForJson movieForJson)
        {
            try
            {
                Movie movie = MovieConverter.ConvertJsonMovieToMovie(movieForJson);

                movieDBContext.Movies.Add(movie);
                movieDBContext.SaveChanges();
                return JsonConvert.SerializeObject(movie);
            }
            catch (Exception e)
            {
                return JsonConvert.SerializeObject("Wrong data");
            }
        }

        [HttpDelete("{id}")]
        public string DeleteMovie(int id)
        {
            var movie = movieDBContext.Movies.Find(id);
            if (movie == null)
            {
                return "Movie not found";
            }
            var movieActorCasts = movieDBContext.MovieActorCasts.Where(ma => ma.MovieId == id).ToList();
            foreach (var item in movieActorCasts)
            {
                movieDBContext.MovieActorCasts.Remove(item);
            }

            var movieUserCasts = movieDBContext.MovieUserCasts.Where(mu => mu.MovieId == id).ToList();
            foreach (var item in movieUserCasts)
            {
                movieDBContext.MovieUserCasts.Remove(item);
            }

            movieDBContext.Movies.Remove(movie);
            movieDBContext.SaveChangesAsync();
            return "Movie was been deleted.";

        }

        private bool MovieExist(int id)
        {
            return movieDBContext.Movies.Any(m => m.Id == id);
        }
    }
}
