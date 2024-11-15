using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVShowsAPI.Models
{
    public class TvShow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Favorite { get; set; }

        // New Properties
        public string Content { get; set; } // Fiction, Animation, or Documentary
        public string Format { get; set; }  // Series, Serial, Reality Show, Comedy, Game Show, Talk Show, Documentary Series, or Animation Series
        public string Episodes { get; set; } // Episodes can be narrative units or have continuity
        public string Duration { get; set; } // Episodes can range from 50 to 60 minutes, or longer in some countries
        public string Scenarios { get; set; } // Can have different settings, both interior and exterior
        public string Classification { get; set; } // G, PG, 14A, 18A, R, E (exempt content)
    }
}
