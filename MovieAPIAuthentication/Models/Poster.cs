using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace MovieAPIAuthentication.Models
{
    public partial class Poster
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fileName")]
        public string FileName { get; set; }

        [JsonProperty("file")]
        public byte[] File { get; set; }
    }
}
