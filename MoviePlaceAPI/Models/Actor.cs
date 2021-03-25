using System;
using System.Collections.Generic;

#nullable disable

namespace MoviePlaceAPI.Models
{
    public partial class Actor
    {
        public Actor()
        {
            MovieActorCasts = new HashSet<MovieActorCast>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<MovieActorCast> MovieActorCasts { get; set; }
    }
}
