using MovieAPIAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPIAuthentication.Utils
{
    public class MovieConverter
    {
        public static MovieForJson ConvertUserToJsonUser(Movie movie)
        {
            MovieForJson movieForJson = new MovieForJson(
                    name: movie.Name,
                    id:movie.Id,
                    description:movie.Description,
                    createdDate:movie.CreatedDate.ToString(),
                    startDate:movie.StartDate.ToString(),
                    length:movie.Length,
                    producerName:movie.ProducerName,
                    budget:movie.Budget,
                    country:movie.Country,
                    countryId:movie.CountryId,
                    category:movie.Category,
                    categoryId:movie.CategoryId,
                    company:movie.Company,
                    companyId:movie.CompanyId,
                    movieActorCasts:movie.MovieActorCasts,
                    movieUserCasts:movie.MovieUserCasts,
                    rating:movie.Rating,
                    imageURL:movie.ImageURL
                );
            return movieForJson;
        }

        public static Movie ConvertJsonMovieToMovie(MovieForJson movieForJson)
        {
            DateTime createdDate = new DateTime();
            DateTime startDate = new DateTime();
            DateTime.TryParse(movieForJson.CreatedDate, out createdDate);
            DateTime.TryParse(movieForJson.StartDate, out startDate);
            Movie movie = new  Movie(
               name: movieForJson.Name,
                    id: movieForJson.Id,
                    description: movieForJson.Description,
                    createdDate: createdDate,
                    startDate:startDate,
                    length: movieForJson.Length,
                    producerName: movieForJson.ProducerName,
                    budget: movieForJson.Budget,
                    country: movieForJson.Country,
                    countryId: movieForJson.CountryId,
                    category: movieForJson.Category,
                    categoryId: movieForJson.CategoryId,
                    company: movieForJson.Company,
                    companyId: movieForJson.CompanyId,
                    movieActorCasts: movieForJson.MovieActorCasts,
                    movieUserCasts: movieForJson.MovieUserCasts,
                    rating: movieForJson.Rating,
                    imageURL: movieForJson.ImageURL
                );
            return movie;
        }
    }
}
