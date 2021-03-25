using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace MovieAPIAuthentication.Models
{
    public partial class Country
    {
        public Country()
        {
            Actors = new HashSet<Actor>();
            Movies = new HashSet<Movie>();
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("population")]
        public long Population { get; set; }

        [JsonProperty("actors")]
        public virtual ICollection<Actor> Actors { get; set; }

        [JsonProperty("movies")]
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
