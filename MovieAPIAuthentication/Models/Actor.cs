using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace MovieAPIAuthentication.Models
{
    public partial class Actor
    {
        public Actor()
        {
            MovieActorCasts = new HashSet<MovieActorCast>();
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("countryId")]
        public int CountryId { get; set; }


        [JsonProperty("country")]
        public virtual Country Country { get; set; }

        [JsonProperty("movieActorCasts")]
        public virtual ICollection<MovieActorCast> MovieActorCasts { get; set; }

        public Actor(int id, string name, string surname, DateTime dateOfBirth, int countryId, Country country, ICollection<MovieActorCast> movieActorCasts)
        {
            Id = id;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            CountryId = countryId;
            Country = country;
            MovieActorCasts = movieActorCasts;
        }
    }
}
