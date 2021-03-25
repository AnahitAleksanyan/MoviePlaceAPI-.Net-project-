using System;
using System.Collections.Generic;

#nullable disable

namespace MoviePlaceAPI.Models
{
    public partial class Country
    {
        public Country()
        {
            Actors = new HashSet<Actor>();
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public long Population { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
