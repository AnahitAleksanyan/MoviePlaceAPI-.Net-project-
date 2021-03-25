using System;
using System.Collections.Generic;

#nullable disable

namespace MoviePlaceAPI.Models
{
    public partial class Company
    {
        public Company()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
