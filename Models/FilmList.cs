using starwars.Infra.Entities;
using System.Collections.Generic;

namespace starwars.Models
{
    public class FilmList
    {
        public int count { get; set; }

        public int? next { get; set; }

        public int? previous { get; set; }

        public List<Film> results { get; set; }
    }
}
