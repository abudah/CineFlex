using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; } = "";
        public DateTime Release_date { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; } = "";
        public string Director { get; set; } = "";
        public float Rating { get; set; }

    }
}
