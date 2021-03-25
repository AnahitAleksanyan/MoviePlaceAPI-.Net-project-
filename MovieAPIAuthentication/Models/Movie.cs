using MoviePlaceAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace MovieAPIAuthentication.Models
{
    public partial class Movie
    {
        public Movie()
        {
            MovieActorCasts = new HashSet<MovieActorCast>();
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imageURL")]
        public string ImageURL { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("producerName")]
        public string ProducerName { get; set; }

        [JsonProperty("budget")]
        public decimal Budget { get; set; }

        [JsonProperty("countryId")]
        public int CountryId { get; set; }

        [JsonProperty("companyId")]
        public int CompanyId { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("rating")]
        public Rating Rating { get; set; }



        [JsonProperty("category")]
        public virtual Category Category { get; set; }

        [JsonProperty("company")]
        public virtual Company Company { get; set; }

        [JsonProperty("country")]
        public virtual Country Country { get; set; }


        [JsonProperty("movieActorCasts")]
        public virtual ICollection<MovieActorCast> MovieActorCasts { get; set; }

        [JsonProperty("MovieUserCasts")]
        public virtual ICollection<MovieUserCast> MovieUserCasts { get; set; }

        public Movie(int id, string name, string description, DateTime createdDate, DateTime startDate, int length, string producerName, string imageURL,decimal budget, int countryId, int companyId, int categoryId, Rating rating, Category category, Company company, Country country, ICollection<MovieActorCast> movieActorCasts, ICollection<MovieUserCast> movieUserCasts)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedDate = createdDate;
            StartDate = startDate;
            Length = length;
            ProducerName = producerName;
            Budget = budget;
            CountryId = countryId;
            CompanyId = companyId;
            CategoryId = categoryId;
            Rating = rating;
            Category = category;
            Company = company;
            Country = country;
            MovieActorCasts = movieActorCasts;
            MovieUserCasts = movieUserCasts;
            ImageURL = imageURL;
        }
    }
}
