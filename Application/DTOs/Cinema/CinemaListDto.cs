using Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Cinema
{
    public class CinemaListDto : BaseDto
    {
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public int Capacity { get; set; }
    }
}
