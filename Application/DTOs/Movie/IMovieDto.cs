using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Movie
{
    public interface IMovieDto 
    {
        public string Title { get; set; }
        public DateTime Release_date { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; } 
        public float Rating { get; set; }
    }
}
