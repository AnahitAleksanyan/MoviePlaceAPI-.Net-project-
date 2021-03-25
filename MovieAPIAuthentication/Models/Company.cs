using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace MovieAPIAuthentication.Models
{
    public partial class Company
    {
        public Company()
        {
            Movies = new HashSet<Movie>();
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("movies")]
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
