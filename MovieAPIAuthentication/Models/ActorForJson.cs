using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPIAuthentication.Models
{
    public class ActorForJson
    {
            public ActorForJson()
            {
                MovieActorCasts = new HashSet<MovieActorCast>();
            }

        public ActorForJson(int id, string name, string surname, string dateOfBirth, int countryId, Country country, ICollection<MovieActorCast> movieActorCasts)
        {
            Id = id;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            CountryId = countryId;
            Country = country;
            MovieActorCasts = movieActorCasts;
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("countryId")]
        public int CountryId { get; set; }


        [JsonProperty("country")]
        public virtual Country Country { get; set; }

        [JsonProperty("movieActorCasts")]
        public virtual ICollection<MovieActorCast> MovieActorCasts { get; set; }
    }
}
