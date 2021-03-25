using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace MovieAPIAuthentication.Models
{
    public partial class MovieActorCast
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("movieId")]
        public int MovieId { get; set; }

        [JsonProperty("actorId")]
        public int ActorId { get; set; }

        [JsonProperty("actor")]
        public virtual Actor Actor { get; set; }

        [JsonProperty("movie")]
        public virtual Movie Movie { get; set; }
    }
}
