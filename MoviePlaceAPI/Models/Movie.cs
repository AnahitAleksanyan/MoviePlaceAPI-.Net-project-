using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace MoviePlaceAPI.Models
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

        [JsonProperty("posterId")]
        public int PosterId { get; set; }

        [JsonProperty("category")]
        public virtual Category Category { get; set; }

        [JsonProperty("company")]
        public virtual Company Company { get; set; }

        [JsonProperty("country")]
        public virtual Country Country { get; set; }

        [JsonProperty("poster")]
        public virtual Poster Poster { get; set; }

        [JsonProperty("movieActorCasts")]
        public virtual ICollection<MovieActorCast> MovieActorCasts { get; set; }
    }
}
