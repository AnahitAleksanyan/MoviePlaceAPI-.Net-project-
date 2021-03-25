using System;
using System.Collections.Generic;

#nullable disable

namespace MoviePlaceAPI.Models
{
    public partial class Poster
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] File { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
