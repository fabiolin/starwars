using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace starwars.Infra.Entities
{
    public class Film : BaseEntity
    {
        //public List<string> characters { get; set; }

        public string director { get; set; }

        public string episode_id { get; set; }

        public string opening_crawl { get; set; }

        //public string planets { get; set; }

        public string producer { get; set; }

        public string release_date { get; set; }

        //public string species { get; set; }

        //public string starships { get; set; }

        public string title { get; set; }

        public string url { get; set; }

        //public string vehicles { get; set; }
    }
}
