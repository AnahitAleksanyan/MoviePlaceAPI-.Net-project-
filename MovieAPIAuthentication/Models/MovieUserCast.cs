using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace MovieAPIAuthentication.Models
{
    public partial class MovieUserCast
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("movieId")]
        public int MovieId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("tbIUser")]
        public virtual TbIuser TbIuser { get; set; }

        [JsonProperty("movie")]
        public virtual Movie Movie { get; set; }
    }
}
